using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using System.IO;

    //0   "The song or lyric does not exist",
	//1	"Are you sure to clear all?" ,
	//2	"Prompt",
	//3	"Invalid link:ID error",
	//4	"Error", 
	//5	"Unknown error,please check the list", 
	//6	"The song already exists in the list",
	//7	"Invalid link", 
	//8	"Please enter the song's link", 
	//9	"The link in the clipboard is invalid", 
	//10	"By doing so,the last decimal of the timeline will be removed,\r\nso that the lyric works on some devices that does not recoginize 3 decimals\r\n\r\nfor example,[00.00.000]->[00.00.00]\r\n[00.00.00]->[00.00.0]"
		
	//0	"该歌曲不存在或没有歌词！",
	//1	"确定清空吗?",
	//2	"提示",
	//3	"歌曲链接错误：ID错误",
	//4	"错误",
	//5	"未知错误，请检查列表",
	//6	"该歌曲已存在",
	//7	"链接无效",
	//8	"请输入歌曲链接",
	//9	"剪贴板中链接错误",			
	//10	"此操作会将时间轴中的最后一位小数去掉，\r\n便于某些不能识别三位小数的设备使用\r\n\r\n例如：[00.00.000]->[00.00.00]\r\n[00.00.00]->[00.00.0]"



namespace neteaseMusicLrcFetcher
{
    public partial class Form1 : Form
    {
        public string strPrefix = "http://music.163.com/api/song/lyric?os=pc&id=";
        public string strSongAPI = "http://music.163.com/api/song/detail/?id=";
        public string strURL;
        public long ID;
        public int idToDel;
        public string[][] lyrlist = new string[999][];
        public string[] ENGString = { "The song or lyric does not exist", "Are you sure to clear all?", "Prompt", "Invalid link:ID error", "Error", "Unknown error,please check the list", "The song already exists in the list", "Invalid link", "Please enter the song's link", "The link in the clipboard is invalid", "By doing so,the last decimal of the timeline will be removed,\r\nso that the lyric works on some devices that does not recoginize 3 decimals\r\n\r\nfor example,[00.00.000]->[00.00.00]\r\n[00.00.00]->[00.00.0]" };
        public string[] CHNString = { "该歌曲不存在或没有歌词！", "确定清空吗?", "提示", "歌曲链接错误：ID错误", "错误", "未知错误，请检查列表", "该歌曲已存在", "链接无效", "请输入歌曲链接", "剪贴板中链接错误", "此操作会将时间轴中的最后一位小数去掉，\r\n便于某些不能识别三位小数的设备使用\r\n\r\n例如：[00.00.000]->[00.00.00]\r\n[00.00.00]->[00.00.0]" };
        public string[] langToUse;

        public class Lrc
        {
            public string version { get; set; }
            public string lyric { get; set; }
        }
        public class Tlyric
        {
            public string version { get; set; }
            public string lyric { get; set; }
        }
        public class Klyric
        {
            public string version { get; set; }
            public string lyric { get; set; }
        }
        public class objectLyric
        {
            public Lrc lrc { get; set; }
            public Klyric klyric { get; set; }
            public Tlyric tlyric { get; set; }
        }
        public class art
        {
            public List<objectName> name { get; set; }
        }
        public class song1
        {
            public List<objectName> songs { get; set; }
        }
        public class objectName
        {
            public string name { get; set; }
            public List<objectName> artists { get; set; }
        }


        public void setLangEN()
        {
            langToUse = ENGString;
            label1.Text = "Link：";
            label2.Text = "Name：";
            label3.Text = "Artist：";
            label4.Text = "Save Folder(Click here to change location)";
            pasteAndAdd.Text = "Paste and add";
            addToList.Text = "Add to list";

            delAll.Text = "Clear List";
            btnFetchLyric.Text = "Fetch all";
            button1.Text = "Remove a decimal";
            Text = "Netease Music Lyric Fetcher";
            saveAll.Text = "Save all";
        }

        public void setLangCN()
        {
            langToUse = CHNString;
            label1.Text = "链接：";
            label2.Text = "歌名：";
            label3.Text = "歌手：";
            label4.Text = "保存文件夹：(点此更改保存位置)";
            pasteAndAdd.Text = "粘贴并添加";
            addToList.Text = "添加到列表";

            delAll.Text = "清空列表";
            btnFetchLyric.Text = "获取所有";
            btnFetchLyric.Text = "获取所有";
            button1.Text = "去除一位小数";
            Text = "网易云歌词批量获取";
            saveAll.Text = "保存全部";
        }



        public void clearLyricList()
        {
            lyrlist = new string[999][];
            singer.Clear();
            songName.Clear();
        }
        private void AllSave()
        {
            string path;
            path = textBox1.Text + "/" + singer.Text + " - " + songName.Text + ".lrc";
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter textWriter = new StreamWriter(fs, Encoding.UTF8);
            textWriter.Write(lyricDisplay.Text);
            textWriter.Close();
        }


        public string fetchArtist(long ID)
        {
            string song;
            strURL = strSongAPI + ID.ToString() + "&" + "ids=%5B" + ID.ToString() + "%5D";
            HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader responseStream = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            song = responseStream.ReadToEnd();
            responseStream.Close();
            objectName songa = JsonConvert.DeserializeObject<objectName>(song);
            song1 a = JsonConvert.DeserializeObject<song1>(song);

            int Num = 0;
            string ToReturn = "";

            try
            {
                while (a.songs[0].artists[Num].name.ToString() != "" || a.songs[0].artists[Num].name.ToString() != null)
                {
                    ToReturn = ToReturn + "," + a.songs[0].artists[Num].name.ToString();
                    Num++;
                }
            }
            catch
            {

            }
            //}
            if (ToReturn.StartsWith(","))
            {
                return ToReturn.TrimStart(",".ToCharArray());
            }
            else
            {
                return ToReturn;
            }



        }

        public string fetchName(long ID)
        {
            string song;
            strURL = strSongAPI + ID.ToString() + "&" + "ids=%5B" + ID.ToString() + "%5D";
            //MessageBox.Show(strURL);
            HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader responseStream = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            song = responseStream.ReadToEnd();
            responseStream.Close();
            objectName songa = JsonConvert.DeserializeObject<objectName>(song);
            song1 a = JsonConvert.DeserializeObject<song1>(song);
            if (a.songs[0].name != "" && a.songs[0].name != null)
            {
                return a.songs[0].name.ToString();
            }
            else
            {
                return "";
            }

        }
        public string fetchLyric(long ID)
        {
            string plyric;
            strURL = strPrefix + ID.ToString() + "&lv=-1&kv=-1&tv=-1";
            //MessageBox.Show(strURL);
            HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader responseStream = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            plyric = responseStream.ReadToEnd();
            responseStream.Close();
            objectLyric lyr = JsonConvert.DeserializeObject<objectLyric>(plyric);
            if (lyr.lrc.lyric != "" && lyr.lrc.lyric != null)
            {
                if (lyr.tlyric.lyric == null)
                {
                    return lyr.lrc.lyric.ToString();
                }
                else
                {
                    return lyr.lrc.lyric.ToString() + "\n" + lyr.tlyric.lyric.ToString();
                }
            }
            else
            {
                return langToUse[0];
            }
        }


        public static NameValueCollection GetQueryString(string queryString)
        {
            return GetQueryString(queryString, null, true);
        }
        public static NameValueCollection GetQueryString(string queryString, Encoding encoding, bool isEncoded)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                int count = queryString.Length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i;
                    int index = -1;
                    while (i < count)
                    {
                        char item = queryString[i];
                        if (item == '=')
                        {
                            if (index < 0)
                            {
                                index = i;
                            }
                        }
                        else if (item == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key = null;
                    string value = null;
                    if (index >= 0)
                    {
                        key = queryString.Substring(startIndex, index - startIndex);
                        value = queryString.Substring(index + 1, (i - index) - 1);
                    }
                    else
                    {
                        key = queryString.Substring(startIndex, i - startIndex);
                    }
                    if (isEncoded)
                    {
                        result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                    }
                    else
                    {
                        result[key] = value;
                    }
                    if ((i == (count - 1)) && (queryString[i] == '&'))
                    {
                        result[key] = string.Empty;
                    }
                }
            }
            return result;
        }
        public static string MyUrlDeCode(string str, Encoding encoding)
        {
            if (encoding == null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                     
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);
                //将已经解码的字符再次进行编码.
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("gb2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setLangCN();
            textBox1.Text = Environment.CurrentDirectory;

        }








        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断是否右键点击
            {
                Point p = e.Location;//获取点击的位置
                int index = songList.IndexFromPoint(p);
                songList.SelectedIndex = index;
                if (index != -1)
                {
                    Point point = new Point(MousePosition.X, MousePosition.Y);
                    rightClickMenu.Show(point);
                    idToDel = index;
                }
            }
            if (e.Button == MouseButtons.Left)
            {

                if (songList.SelectedIndex != -1)
                {
                    try
                    {
                        songName.Text = lyrlist[songList.SelectedIndex][0].ToString();
                        singer.Text = lyrlist[songList.SelectedIndex][1].ToString();
                        lyricDisplay.Text = lyrlist[songList.SelectedIndex][2].ToString();
                    }
                    catch { }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = songList.SelectedIndex;
            songList.Items.Remove(songList.SelectedItem);
            if (i < songList.Items.Count)
            {
                //i++;
                songList.SetSelected(i, true);
                songName.Text = lyrlist[songList.SelectedIndex][0].ToString();
                singer.Text = lyrlist[songList.SelectedIndex][1].ToString();
                lyricDisplay.Text = lyrlist[songList.SelectedIndex][2].ToString();
            }
            else
            {
                i--;
                if (i != -1)
                {
                    songList.SetSelected(i, true);
                    songName.Text = lyrlist[songList.SelectedIndex][0].ToString();
                    singer.Text = lyrlist[songList.SelectedIndex][1].ToString();
                    lyricDisplay.Text = lyrlist[songList.SelectedIndex][2].ToString();
                }
                else
                {

                    songName.Clear();
                    lyricDisplay.Clear();

                }
            }
            if (songList.Items.Count == 0)
            {
                clearLyricList();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(langToUse[1], langToUse[2], MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                clearLyricList();
                lyricDisplay.Clear();
                singer.Clear();
                songName.Clear();
                songList.Items.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearLyricList();
            int num = songList.Items.Count;
            num--;
            int toIns = 0;
            foreach (var sID in songList.Items)
            {
                try
                {
                    lyrlist[toIns] = new string[999];
                    lyrlist[toIns][0] = fetchName(Convert.ToInt32(sID)).ToString();
                    lyrlist[toIns][1] = fetchArtist(Convert.ToInt32(sID)).ToString();
                    lyrlist[toIns][2] = fetchLyric(Convert.ToInt32(sID)).ToString();
                    lyrlist[toIns][2] = lyrlist[toIns][2].Replace("\n", Environment.NewLine);
                    toIns++;
                }
                catch
                {
                    MessageBox.Show(langToUse[3], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toIns++;
                }



            }
            try
            {

                songName.Text = lyrlist[0][0].ToString();
                lyricDisplay.Text = lyrlist[0][2].ToString();
                singer.Text = lyrlist[0][1].ToString();
                songList.SetSelected(0, true);
            }
            catch
            {
                MessageBox.Show(langToUse[5], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (songLink.Text != "")
            {
                try
                {
                    string pageURL = songLink.Text;
                    Uri uri = new Uri(pageURL);
                    string queryString = uri.Query;
                    NameValueCollection col = GetQueryString(queryString);
                    string ID = col["id"];
                    if (ID != "")
                    {
                        if (this.songList.Items.Contains(ID) == false)
                        {
                            if (Regex.IsMatch(ID, @"^-?\d+\.?\d*$") && ID != "0")
                            {
                                songList.Items.Add(ID);
                            }
                            else
                            {
                                MessageBox.Show(langToUse[3], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show(langToUse[6], langToUse[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(langToUse[3], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch
                {
                    MessageBox.Show(langToUse[7], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show(langToUse[8], langToUse[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                string clipboardText = Clipboard.GetText(TextDataFormat.Text);
                if (clipboardText.StartsWith("http://") || clipboardText.StartsWith("https://"))
                {
                    songLink.Text = clipboardText;
                    addToList.PerformClick();


                }
                else
                {
                    MessageBox.Show(langToUse[9], langToUse[4], MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(langToUse[10], langToUse[2], MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                lyricDisplay.Text = Regex.Replace(lyricDisplay.Text, @"\d{1}]", "]");
            }

        }

        private void lyricDisplay_TextChanged(object sender, EventArgs e)
        {
        }

        private void songList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                setLangCN();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                setLangEN();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int num = 0; num < songList.Items.Count; num++)
            {
                songList.SetSelected(num, true);
                if (songList.SelectedIndex != -1)
                {
                    try
                    {
                        songName.Text = lyrlist[songList.SelectedIndex][0].ToString();
                        singer.Text = lyrlist[songList.SelectedIndex][1].ToString();
                        lyricDisplay.Text = lyrlist[songList.SelectedIndex][2].ToString();
                    }
                    catch { }
                }
                    AllSave();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = textBox1.Text;
            }
            catch { }
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void singer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
