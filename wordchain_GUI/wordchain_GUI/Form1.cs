using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordChain;

namespace wordchain_GUI
{
    public partial class Form1 : Form
    {

        Core core;

//        bool check_wc = false;
//        bool check_TextFile = false;

        int wc_mode = 0;
        bool input_isfile = false ;

        char head;
        char tail;


        public Form1()
        {
            InitializeComponent();
            //core = new Core();
            input_text.Checked = true ;
            word_mode.Checked = true ;
        }

        /*
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        //    core.EnableLoop = checkBox1.Checked;
            
        }
        */

        /*
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            //core.WordMode = radioButton1.Checked;
            //core.CharMode = !radioButton1.Checked;
            wc_mode = word_mode.Checked ? 0 : 1;
         //   check_wc = true;
        }
        */

        /*
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //core.CharMode = radioButton2.Checked;
            //core.WordMode = !radioButton2.Checked;
            wc_mode = char_mode.Checked ? 1 : 0;
            //check_wc = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        //    check_TextFile = true;
            input_isfile = !input_text.Checked;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
        //    check_TextFile = true;
            input_isfile = input_file.Checked;
        }
        */

            /*
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        */

        /*
        private void TextBox1_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void TextBox1_PreviewDrop(object sender, DragEventArgs e)
        {
            foreach (string f in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                textBox1.Text = f;
            }
        }*/

        /*
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
        //    e.Effect = DragDropEffects.Copy;
            
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            
        }
        */

        /*
        private void textBox1_DragDrop(object sender,DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            inputText.Text = path;
        }
        */

        /*
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        */

        /*
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (head_mode.Checked == false)
                head = '\0';
            else
            {
                head = (char)('a' + head_alpha.SelectedIndex);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (head_mode.Checked)
                head = (char)('a' + head_alpha.SelectedIndex);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (tail_mode.Checked == false)
                tail = '\0';
            else
            {
                tail = (char)('a' + tail_alpha.SelectedIndex);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tail_mode.Checked)
                tail = (char)('a' + tail_alpha.SelectedIndex);
        }
        */

            /*
        private void button1_Click(object sender, EventArgs e)
        {

                if (outputFile.Checked)
                    core = new Core(input: inputText.Text, mode: wc_mode, head: head, tail: tail, enableLoop: enableLoop.Checked , inputIsFile : input_isfile);
                else
                    core = new Core(input: inputText.Text, mode: wc_mode, head: head, tail: tail, enableLoop: enableLoop.Checked, outputFilePath: inputText.Text , inputIsFile : input_isfile);

                List<string> chain = new List<string>() ;
                try
                {
                    result.Text = "计算结果：";
                    if (outputFile.Checked)
                    {
                        chain = core.GenerateChain(true);
                        result.Text = "计算结果：";
                        MessageBox.Show("已导出至指定文件！");
                    }
                    else
                    {
                        chain = core.GenerateChain(false);
                        output(chain);
                    }
                }
                catch(ProgramException ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }
        */

        /*
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }*/

        

        /*
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        */

     

        private void enableLoop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void word_mode_CheckedChanged(object sender, EventArgs e)
        {
            wc_mode = word_mode.Checked ? 0 : 1;
        }

        private void char_mode_CheckedChanged(object sender, EventArgs e)
        {
            wc_mode = char_mode.Checked ? 1 : 0;
        }

        private void input_text_CheckedChanged(object sender, EventArgs e)
        {
            input_isfile = !input_text.Checked;
        }

        private void input_file_CheckedChanged(object sender, EventArgs e)
        {
            input_isfile = input_file.Checked;
        }

        private void select_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                inputText.Text = dlg.FileName;
                input_file.Checked = true;
                input_text.Checked = false;
                input_isfile = true;
            }
                
            //MessageBox.Show(dlg.FileName);
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void head_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (head_mode.Checked == false)
                head = '\0';
            else
            {
                head = (char)('a' + head_alpha.SelectedIndex);
            }
        }

        private void head_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (head_mode.Checked)
                head = (char)('a' + head_alpha.SelectedIndex);
        }

        private void tail_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (tail_mode.Checked == false)
                tail = '\0';
            else
            {
                tail = (char)('a' + tail_alpha.SelectedIndex);
            }
        }

        private void tail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tail_mode.Checked)
                tail = (char)('a' + tail_alpha.SelectedIndex);
        }

        private void outputFile_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void output_filePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {
            if (outputFile.Checked)
                core = new Core(input: inputText.Text, mode: wc_mode, head: head, tail: tail, enableLoop: enableLoop.Checked, outputFilePath: output_filePath.Text, inputIsFile: input_isfile);
            else
                core = new Core(input: inputText.Text, mode: wc_mode, head: head, tail: tail, enableLoop: enableLoop.Checked, inputIsFile: input_isfile);
            

            List<string> chain = new List<string>();
            try
            {
                result.Text = "计算结果：";
                if (outputFile.Checked)
                {
                    chain = core.GenerateChain(true);
                    result.Text = "计算结果：";
                    MessageBox.Show("已导出至指定文件！");
                }
                else
                {
                    chain = core.GenerateChain(false);
                    output(chain);
                }
            }
            catch (ProgramException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void result_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void output(List<string> chain)
        {

            for (int i = 0; i < chain.Count; i++)
                result.Text = result.Text + '\n' + chain[i];

        }
    }
}
