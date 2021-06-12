using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace certificateComparer1
{
    public partial class mainForm : Form
    {
        String myCurrentDir = "";

        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //カレントディレクトリ取得
            myCurrentDir = System.IO.Directory.GetCurrentDirectory();


        }

        // 秘密鍵を選択するボタンが押されたとき
        private void btn_SelectKey_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //タイトルを設定する
            ofd.Title = "Select your key file - 秘密鍵を選択";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                txtFileSecretKey.Text = ofd.FileName;
            }
        }


        // サーバ証明書を選択するボタンが押されたとき
        private void btn_SelectServerCertificate_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //タイトルを設定する
            ofd.Title = "Select your Server-Certificate file - サーバ証明書を選択";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                txtFileServerCertificate.Text = ofd.FileName;
            }
        }

        // 中間証明書を選択するボタンが押されたとき
        private void btn_SelectIntermediateCertificate_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //タイトルを設定する
            ofd.Title = "Select your Intermediate-Certificate file - 中間証明書を選択";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                txtFileIntermediateCertificate.Text = ofd.FileName;
            }
        }

        // ルート証明書を選択するボタンが押されたとき
        private void btn_SelectRootCertificate_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //タイトルを設定する
            ofd.Title = "Select your Intermediate-Certificate file - ルート証明書を選択";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                txtFileRootCertificate.Text = ofd.FileName;
            }
        }


        // 比較ボタンを押したとき
        private void btnCompare_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "";

            lblAnswer_key_and_server.BackColor = Color.Silver;
            lblAnswer_key_and_server.Text = "NOT compared yet.";

            lblAnswer_server_and_intermediate.BackColor = Color.Silver;
            lblAnswer_server_and_intermediate.Text = "NOT compared yet.";

            lblAnswer_root_and_intermediate.BackColor = Color.Silver;
            lblAnswer_root_and_intermediate.Text = "NOT compared yet.";

            lblInfo_serverCertificate.Text = "_";
            lblInfo_intermediateCertificate.Text = "_";
            lblInfo_rootCertificate.Text = "_";

            btnCompare.BackColor = Color.Yellow;
            btnCompare.Text = "Compareing now...";

            tmrStartCompare.Start();
        }

        // 比較処理
        private void tmrStartCompare_Tick(object sender, EventArgs e)
        {
            tmrStartCompare.Stop();

            try
            {
                // 1 サーバ証明書の発行先、発行者、有効期限を取得
                getInfoServerCertificate();

                // 2 中間証明書の発行先、発行者、有効期限を取得
                getInfoIntermediateCertificate();

                // 3 ルート証明書の発行先、発行者、有効期限を取得
                getInfoRootCertificate();


                // 11 [サーバ秘密鍵]と[サーバ証明書]が指定されているときは、[鍵]-[サーバ]両者を比較。
                compareKeyAndServer();

                // 12 [サーバ証明書]と[中間証明書]が指定されている場合は、[サーバ]-[中間]両者を比較。
                compareServerAndIntermediate();

                // 13 [ルート証明書]と[中間証明書]が指定されている場合は、[ルート]-[中間]両者を比較。
                compareIntermediateAndRoot();

                               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check your selected file's path is TOO DEEP.\r\n選択したファイルのパスが深すぎると処理できません。確認してください。\r\n\r\n(Exception Message: "+ex.Message+")","ERROR");
                txtStatus.Text += "\r\nERROR. Please check your selected files' paths are TOO DEEP.\r\n選択したファイルのパスが深すぎないか確認してください。\r\n(Exception："+ex.Message+")";
            }

            txtStatus.SelectionStart = txtStatus.Text.Length;
            txtStatus.Focus();
            txtStatus.ScrollToCaret();

            btnCompare.Text = "Compare\r\n比較開始";
            btnCompare.BackColor = Color.Silver;
            
        }




        //////////////////// 1 サーバ証明書の発行先、発行者、有効期限を取得
        private void getInfoServerCertificate()
        {
            
            if (txtFileServerCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nGetting SERVER-certificate information(サーバ証明書情報). \r\n";

                String subjectCN = "";//発行先　(たいがいドメイン)
                String issuerCN = ""; //発行者　(DigiCertとか)
                String notBefore = ""; //有効期限開始
                String notAfter = ""; //有効期限終了

                //コマンド実行 openssl x509 -text -noout -in XXX.pem
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -text -noout -in \"" + txtFileServerCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String message;
                while (true)
                {
                    message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else if (message.IndexOf("Subject:") > 1)
                    {
                        subjectCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Issuer:") > 1)
                    {
                        issuerCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Before") > 1)
                    {
                        notBefore = message.Substring(message.IndexOf(":") + 1);
                    }
                    else if (message.IndexOf("After") > 1)
                    {
                        notAfter = message.Substring(message.IndexOf(":") + 1);
                    }
                }

                lblInfo_serverCertificate.Text = "Subject-CN(発行先): " + subjectCN + "\r\nIssuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter;
                txtStatus.Text += "Subject-CN(発行先): " + subjectCN + "     Issuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter+"\r\n";
            }
        }

        //////////////////// 2 中間証明書の発行先、発行者、有効期限を取得
        private void getInfoIntermediateCertificate()
        {
            
            if (txtFileServerCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nGetting INTERMEDIATE-certificate information(中間証明書情報). \r\n";

                String subjectCN = "";//発行先　(たいがいドメイン)
                String issuerCN = ""; //発行者　(DigiCertとか)
                String notBefore = ""; //有効期限開始
                String notAfter = ""; //有効期限終了

                //コマンド実行 openssl x509 -text -noout -in XXX.pem
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -text -noout -in \"" + txtFileIntermediateCertificate.Text +"\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String message;
                while (true)
                {
                    message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else if (message.IndexOf("Subject:") > 1)
                    {
                        subjectCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Issuer:") > 1)
                    {
                        issuerCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Before") > 1)
                    {
                        notBefore = message.Substring(message.IndexOf(":") + 1);
                    }
                    else if (message.IndexOf("After") > 1)
                    {
                        notAfter = message.Substring(message.IndexOf(":") + 1);
                    }
                }

                lblInfo_intermediateCertificate.Text = "Subject-CN(発行先): " + subjectCN + "\r\nIssuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter;
                txtStatus.Text += "Subject-CN(発行先): " + subjectCN + "     Issuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter + "\r\n";
            }
        }






        //////////////////// 3 ルート証明書の発行先、発行者、有効期限を取得
        private void getInfoRootCertificate()
        {
            
            if (txtFileServerCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nGetting ROOT-certificate information(ルート証明書情報). \r\n";

                String subjectCN = "";//発行先　(たいがいドメイン)
                String issuerCN = ""; //発行者　(DigiCertとか)
                String notBefore = ""; //有効期限開始
                String notAfter = ""; //有効期限終了

                //コマンド実行 openssl x509 -text -noout -in XXX.pem
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -text -noout -in \"" + txtFileRootCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String message;
                while (true)
                {
                    message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else if (message.IndexOf("Subject:") > 1)
                    {
                        subjectCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Issuer:") > 1)
                    {
                        issuerCN = message.Substring(message.IndexOf("CN=") + 3);
                    }
                    else if (message.IndexOf("Before") > 1)
                    {
                        notBefore = message.Substring(message.IndexOf(":") + 1);
                    }
                    else if (message.IndexOf("After") > 1)
                    {
                        notAfter = message.Substring(message.IndexOf(":") + 1);
                    }
                }

                lblInfo_rootCertificate.Text = "Subject-CN(発行先): " + subjectCN + "\r\nIssuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter;
                txtStatus.Text += "Subject-CN(発行先): " + subjectCN + "     Issuer-CN(発行者): " + issuerCN + "\r\nLimit(有効期限): " + notBefore + " - " + notAfter + "\r\n";
            }
        }






        ///////// 11 [サーバ秘密鍵]と[サーバ証明書]が指定されているときは、[鍵]-[サーバ]両者を比較。
        private void compareKeyAndServer(){
            
            if (txtFileSecretKey.Text.Length > 5 && txtFileServerCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nCompareing KEY <--> SERVER certificate \r\n";

                ///////////////// 11-1 鍵のModules値を取得
                String keyModulus = ""; //鍵のModule値

                //コマンド実行 openssl rsa -modulus -noout -in XXX.key
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " rsa -modulus -noout -in \"" + txtFileSecretKey.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Modulus値を取得
                keyModulus = process.StandardOutput.ReadLine();
                txtStatus.Text += "KEY modulus: " + keyModulus + "\r\n";



                /////////////////// 11-2 サーバ証明書のModules値を取得
                String serverModulus = ""; //サーバ証明書のModulus

                //コマンドを実行 openssl x509 -modulus -noout -in XXX.pem
                process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -modulus -noout -in \"" + txtFileServerCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Modulus値を取得
                serverModulus = process.StandardOutput.ReadLine();

                txtStatus.Text += "Server Certificate Modulus: " + serverModulus + "\r\n";




                //////////// 11-3 鍵とサバ証の整合性確認
                if (serverModulus.IndexOf(keyModulus) >= 0 && keyModulus.IndexOf(serverModulus) >= 0)
                {
                    lblAnswer_key_and_server.Text = "OK. MATCH.";
                    txtStatus.Text += "KEY & Server Certificate: OK. MATCH." + "\r\n";
                    lblAnswer_key_and_server.BackColor = Color.Aqua;
                }
                else
                {
                    lblAnswer_key_and_server.Text = "NG! NOT match!";
                    txtStatus.Text += "KEY & Server Certificate: NG! NOT match!" + "\r\n";
                    lblAnswer_key_and_server.BackColor = Color.Red;
                }

            }
        }






        ////// 12 [サーバ証明書]と[中間証明書]が指定されている場合は、[サーバ]-[中間]両者を比較。
        private void compareServerAndIntermediate()
        {
            
            if (txtFileIntermediateCertificate.Text.Length > 5 && txtFileServerCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nCompareing SERVER-certificate issuer-hash <--> INTERMEDIATE-certificate subject-hash \r\n";

                ////////////// 12-1 サーバ証明書の機関キー識別子取得

                // openssl x509 -issuer_hash -noout -in server.pem
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -issuer_hash -noout -in \"" + txtFileServerCertificate.Text +"\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String serverIssuerHash = "";
                while (true)
                {
                    string message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else
                    {
                        message = message.Replace(" ", "");
                        serverIssuerHash += message;
                    }
                }

                txtStatus.Text += "SERVER-certificate ISSUER-hash:" + serverIssuerHash + "\r\n";




                ////////////// 12-2 中間証明書のサブジェクトキー識別子取得

                // openssl x509 -subject_hash -noout -in server-ca.pem  
                process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -subject_hash -noout -in \"" + txtFileIntermediateCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String intermediateSubjectHash = "";
                while (true)
                {
                    string message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else
                    {
                        message = message.Replace(" ", "");
                        intermediateSubjectHash += message;
                    }
                }


                txtStatus.Text += "INTERMEDIATE-certificate SUBJECT-hash:" + intermediateSubjectHash + "\r\n";



                //////////// 12-3 中間とサバ証の整合性確認

                Console.WriteLine(serverIssuerHash);
                Console.WriteLine(intermediateSubjectHash);

                if (serverIssuerHash.IndexOf(intermediateSubjectHash) >= 0 && intermediateSubjectHash.IndexOf(serverIssuerHash) >= 0)
                {
                    lblAnswer_server_and_intermediate.Text = "OK. MATCH";
                    txtStatus.Text += "INTERMEDIATE certificate & SERVER certificate: OK. MATCH." + "\r\n";
                    lblAnswer_server_and_intermediate.BackColor = Color.Aqua;
                }
                else
                {
                    lblAnswer_server_and_intermediate.Text = "NG! NOT match!";
                    txtStatus.Text += "INTERMEDIATE certificate & SERVER certificate: NG! NOT match!" + "\r\n";
                    lblAnswer_server_and_intermediate.BackColor = Color.Red;
                }

            }
        }






        ////// 13 [ルート証明書]と[中間証明書]が指定されている場合は、[ルート]-[中間]両者を比較。
        private void compareIntermediateAndRoot()
        {
            
            if (txtFileIntermediateCertificate.Text.Length > 5 && txtFileRootCertificate.Text.Length > 5)
            {
                txtStatus.Text += "\r\nCompareing INTERMEDIATE-certificate ISSUER-hash <--> ROOT-certificate SUBJECT-hash. \r\n";

                ////////////// 13-1 中間証明書の機関キー識別子取得

                // openssl x509 -issuer_hash -noout -in server.pem
                Process process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -issuer_hash -noout -in \"" + txtFileIntermediateCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String intermediateIssuerHash = "";
                while (true)
                {
                    string message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else
                    {
                        message = message.Replace(" ", "");
                        intermediateIssuerHash += message;
                    }
                }

                txtStatus.Text += "INTERMEDIATE-certificate ISSUER-hash:" + intermediateIssuerHash + "\r\n";




                ////////////// 13-2 ルート証明書のサブジェクトキー識別子取得

                // openssl x509 -subject_hash -noout -in server-ca.pem  
                process = new Process();
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;

                process.StartInfo.FileName = myCurrentDir + "\\bin\\openssl.exe";
                process.StartInfo.Arguments = " x509 -subject_hash -noout -in \"" + txtFileRootCertificate.Text + "\"";
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.Flush();
                process.StandardInput.Close();

                String rootSubjectHash = "";
                while (true)
                {
                    string message = process.StandardOutput.ReadLine();
                    if (message == null)
                    {
                        break;
                    }
                    else
                    {
                        message = message.Replace(" ", "");
                        rootSubjectHash += message;
                    }
                }


                txtStatus.Text += "ROOT-certificate SUBJECT-hash:" + rootSubjectHash + "\r\n";



                //////////// 13-3 中間とサバ証の整合性確認

                Console.WriteLine(intermediateIssuerHash);
                Console.WriteLine(rootSubjectHash);

                if (intermediateIssuerHash.IndexOf(rootSubjectHash) >= 0 && rootSubjectHash.IndexOf(intermediateIssuerHash) >= 0)
                {
                    lblAnswer_root_and_intermediate.Text = "OK. MATCH";
                    txtStatus.Text += "ROOT certificate & INTERMEDIATE certificate: OK. MATCH." + "\r\n";
                    lblAnswer_root_and_intermediate.BackColor = Color.Aqua;
                }
                else
                {
                    lblAnswer_root_and_intermediate.Text = "NG! NOT match!";
                    txtStatus.Text += "ROOT certificate & INTERMEDIATE certificate: NG! NOT match!" + "\r\n";
                    lblAnswer_root_and_intermediate.BackColor = Color.Red;
                }
            }
        }
    }
}