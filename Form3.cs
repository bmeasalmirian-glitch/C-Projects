using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
namespace WindowsFormsApp18
{
    public partial class Form3 : Form
    {
        int mark = 0;
        //Definition of musical notes
        private string[] fileNames = { "A1.mp3", "A2.mp3","B1.mp3", "C2.mp3", "D2.mp3", "E2.mp3", "F2.mp3", "G1.mp3" };
        private int[] Index = { 0, 2, 3, 4, 5, 5, 5, 1, 5, 5, 1, 5, 1, 5, 5, 6, 4, 5, 3, 4, 5, 3, 4, 2, 3, 4, 2, 3, 0, 2, 3, 0, 2, 7, 0, 3, 2, 3, 0, 2, 7, 0 };
        int curr = 0;
        private IWavePlayer waveOut;
        private AudioFileReader audioFile;
        //Defining and presenting in-game buttons
        Button[] BTNS;
        Button[] btns2;
        Button[] btns3;
        Button[] btns4;
        Button[] btns5;
        Button[] btns6;
        Button[] btns7;
        //Names of buttons defined in the code
        Button selected1, selected2, selected3, selected4, selected5, selected6, selected7, selected8,selected9,selected10,selected11,selected12;
        Button selected13, selected14, selected15, selected16, selected17, selected18;
        Button correct1, correct2, correct3, correct4, correct5, correct6, correct7;
        Button correct8, correct9, correct10, correct11, correct12, correct13, correct14, correct15;
        Button correct16, correct17, correct18, correct19, correct20, correct21, correct22, correct23, correct24;
        //Offering different colors
        string[] clor = { "Yellow", "Blue", "Pink", "Green", "Red", "Black", "Brown", "Gray", "Orange", "Purple" };
        string colorone, colortwo, colorthree;
        Random rnd = new Random();
        Random rnd2 = new Random();
        public Form3()
        {
            InitializeComponent();
            lbStage.Visible = false;
            btnleft.Visible = btnright.Visible = btnBetween.Visible = false;
            btnNext.Visible = false;
            BTNS = new Button[] { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            btns2 = new Button[] { btn10, btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20, btn21 };
            btns3 = new Button[] { btn22,btn23,btn24,btn25,btn26,btn27,btn28,btn29,btn30,btn31,btn32,btn33,btn34,btn35,btn36};
            btns4 = new Button[] { btn37, btn38, btn39, btn40, btn41, btn42, btn43,btn44, btn45, btn46, btn47, btn48, btn49, btn50, btn51, btn52, btn53, btn54 };
            btns5 = new Button[] { btn55, btn56, btn57, btn58, btn59, btn60, btn61, btn62, btn63, btn64, btn65, btn66, btn67, btn68, btn69, btn70, btn71, btn72, btn73, btn74, btn75 };
            btns6 = new Button[] { btn76, btn77, btn78, btn79, btn80, btn81, btn82, btn83, btn84, btn85, btn86, btn87, btn88, btn89, btn90, btn91, btn92, btn93, btn94, btn95, btn96, btn97, btn98, btn99 };
            btns7 = new Button[] { btn100, btn101, btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112, btn113, btn114, btn115, btn116, btn117, btn118, btn119, btn120, btn121, btn122, btn123, btn124, btn125, btn126 };
            int a = rnd.Next(clor.Length);
            int b;
            do
            {
                b = rnd.Next(clor.Length);
            } while (a == b);
            int c;
            do
            {
                c = rnd.Next(clor.Length);
            } while (a == c || c == b);
            colorone = clor[a];
            colortwo = clor[b];
            colorthree = clor[c];
        }
        public void SaveOrUpdateScore(string nationalCode, int newScore)
        {
            string path = GlobalData.FilePath;
            var lines = File.ReadAllLines(path).ToList();
            string targetId = "کدملی :" + nationalCode.Trim();
            string newScoreLine = "امتیاز :" + newScore;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim() == targetId)
                {
                    int j = i;
                    bool scoreUpdated = false;

                    // Move to the separator or end of this user's information
                    while (j < lines.Count && !lines[j].StartsWith("--------------------------------------------------------"))
                    {
                        if (lines[j].StartsWith("امتیاز"))
                        {
                            // Update
                            lines[j] = newScoreLine;
                            scoreUpdated = true;
                            break;
                        }
                        j++;
                    }

                    if (!scoreUpdated)
                    {
                        // If there is no score, insert it before the separator.
                        int insertIndex = j; //Where the separator begins
                        lines.Insert(insertIndex, newScoreLine);
                    }

                    break; 
                }
            }

            File.WriteAllLines(path, lines);
        }
        private void btnStart_Click_1(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            btnleft.Visible = true;
            btnleft.BackColor = Color.FromName(colorone);
            btnBetween.Visible = true;
            btnBetween.BackColor = Color.FromName(colortwo);
            btnright.Visible = true;
            btnright.BackColor = Color.FromName(colorthree);
            btnNext.Visible = true;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Start the game
        private void btnNext_Click(object sender, EventArgs e)
        {
            lbStage.Visible = true;
            lbStage.Text = "مرحله اول";
            btnNext.Visible = btnleft.Visible = btnright.Visible = btnBetween.Visible = false;
            btn1.Visible = btn2.Visible = btn3.Visible = btn4.Visible = btn5.Visible = btn6.Visible = btn7.Visible = true;
            btn8.Visible = btn9.Visible = true;
            int d = rnd2.Next(9);
            int k;
            do
            {
                k = rnd2.Next(9);
            } while (d == k);
            int f;
            do
            {
                f = rnd2.Next(9);
            } while (f == d || f == k);
            BTNS[d].BackColor = Color.FromName(colorone);
            selected1 = BTNS[d];
            BTNS[k].BackColor = Color.FromName(colorone);
            selected2 = BTNS[k];
            BTNS[f].BackColor = Color.FromName(colorone);
            selected3 = BTNS[f];
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int v = rand.Next(255);
            int x = rand.Next(255);
            int z = rand.Next(255);
            for (int i = 0; i < 9; i++)
            {
                if (i == d || i == k || i == f)
                    continue;
                if (count1 < 3)
                {
                    BTNS[i].BackColor = Color.FromArgb(r, g, b);
                    BTNS[i].Click += Button_Click;
                    this.Controls.Add(BTNS[i]);
                    count1++;
                }
                else if (count2 < 3)
                {
                    BTNS[i].BackColor = Color.FromArgb(v, x, z);
                    BTNS[i].Click += Button_Click;
                    this.Controls.Add(BTNS[i]);
                    count2++;
                }
                if (count1 >= 3 && count2 >= 3)
                    break;

            }
            selected1.Click += Selected1_Click;
            this.Controls.Add(selected1);
            selected2.Click += Selected2_Click;
            this.Controls.Add(selected2);
            selected3.Click += Selected3_Click;
            this.Controls.Add(selected3);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Defining the rank and state of the buttons of different stages
        void Step_B()
        {
            lbStage.Text = "مرحله دوم";
            btn10.Visible = btn11.Visible = btn12.Visible = btn13.Visible = btn14.Visible = true;
            btn15.Visible = btn16.Visible = btn17.Visible = btn18.Visible = btn19.Visible = btn20.Visible = btn21.Visible = true;
            Random rnd3 = new Random();
            int t = rnd3.Next(12);
            int q;
            do
            {
                q = rnd3.Next(12);
            } while (t == q);
            int o;
            do
            {
                o = rnd3.Next(12);
            } while (t == o || o == q);
            int y;
            do
            {
                y = rnd3.Next(12);
            } while (y == o || y == q || y == t);
            btns2[t].BackColor = Color.FromName(colortwo);
            selected4 = btns2[t];
            btns2[q].BackColor = Color.FromName(colortwo);
            selected5 = btns2[q];
            btns2[o].BackColor = Color.FromName(colortwo);
            selected6 = btns2[o];
            btns2[y].BackColor = Color.FromName(colortwo);
            selected7 = btns2[y];
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int u = rand.Next(255);
            int v = rand.Next(255);
            int z = rand.Next(255);
            for (int i = 0; i < 12; i++)
            {
                if (i == t || i == q || i == o || i == y)
                    continue;

                if (count1 < 4)
                {
                    btns2[i].BackColor = Color.FromArgb(r, g, b);
                    btns2[i].Click += Button2_Click;
                    this.Controls.Add(btns2[i]);
                    count1++;
                }
                else if (count2 < 4)
                {
                    btns2[i].BackColor = Color.FromArgb(u, v, z);
                    btns2[i].Click += Button2_Click;
                    this.Controls.Add(btns2[i]);
                    count2++;
                }

                if (count1 >= 4 && count2 >= 4)
                    break;
            }
            selected4.Click += Selected4_Click;
            this.Controls.Add(selected4);
            selected5.Click += Selected5_Click;
            this.Controls.Add(selected5);
            selected6.Click += Selected6_Click;
            this.Controls.Add(selected6);
            selected7.Click += Selected7_Click;
            this.Controls.Add(selected7);
        }
        void Step_C()
        {
            lbStage.Text = "مرحله سوم";
            btn22.Visible = btn23.Visible = btn24.Visible = btn25.Visible = btn26.Visible = btn27.Visible = btn28.Visible = btn29.Visible = true;
            btn30.Visible = btn31.Visible = btn32.Visible = btn33.Visible = btn34.Visible = btn35.Visible = btn36.Visible = true;
            Random rnd3 = new Random();
            int z = rnd3.Next(15);
            int n;
            do
            {
                n = rnd3.Next(15);
            } while (z == n);
            int m;
            do
            {
                m = rnd3.Next(15);
            } while (z == m || m == n);
            int j;
            do
            {
                j = rnd3.Next(15);
            } while (j == n || j == m || j == z);
            int v;
            do
            {
                v = rnd3.Next(15);
            }while (v == n || v == m || v == z || v == j);
            btns3[z].BackColor = Color.FromName(colorthree);
            selected8 = btns3[z];
            btns3[n].BackColor = Color.FromName(colorthree);
            selected9 = btns3[n];
            btns3[m].BackColor = Color.FromName(colorthree);
            selected10 = btns3[m];
            btns3[j].BackColor = Color.FromName(colorthree);
            selected11 = btns3[j];
            btns3[v].BackColor = Color.FromName(colorthree);
            selected12 = btns3[v];
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int u = rand.Next(255);
            int w = rand.Next(255);
            int f = rand.Next(255);
            for (int i = 0; i < 15; i++)
            {
                if (i == z || i == n || i == m || i == j || i == v)
                    continue;
                if(count1 < 5)
                {
                    btns3[i].BackColor=Color.FromArgb(r, g, b);
                    btns3[i].Click += Button3_Click;
                    this.Controls.Add(btns3[i]);
                    count1++;
                }else if(count2 < 5)
                {
                    btns3[i].BackColor = Color.FromArgb(u,w,f);
                    btns3[i].Click += Button3_Click;
                    this.Controls.Add(btns3[i]);
                    count2++;
                }
                if (count1 >= 5 && count2 >= 5)
                    break;
            }
            selected8.Click += Selected8_Click;
            this.Controls.Add(selected8);
            selected9.Click += Selected9_Click;
            this.Controls.Add(selected9);
            selected10.Click += Selected10_Click;
            this.Controls.Add(selected10);
            selected11.Click += Selected11_Click;
            this.Controls.Add(selected11);
            selected12.Click += Selected12_Click;
            this.Controls.Add(selected12);
        }
        void Step_D()
        {
            lbStage.Text = "مرحله چهارم";
            btn37.Visible = btn38.Visible = btn39.Visible = btn40.Visible = btn41.Visible = btn42.Visible = btn43.Visible = btn44.Visible = true;
            btn45.Visible = btn46.Visible = btn47.Visible = btn48.Visible = btn49.Visible = btn50.Visible = btn51.Visible = btn52.Visible = true;
            btn53.Visible = btn54.Visible = true;
            Random rnd4 = new Random();
            int d = rnd4.Next(18);
            int f;
            do
            {
                f = rnd4.Next(18);
            } while (f == d);
            int h;
            do
            {
                h = rnd4.Next(18);
            } while (h == d || h == f);
            int k;
            do
            {
                k = rnd4.Next(18);
            } while (k == h || k == f || k == d);
            int j;
            do
            {
                j= rnd4.Next(18);
            } while (j == k || j == h || j == f || j == d);
            int l;
            do
            {
                l = rnd4.Next(18);
            } while (l == j || l == k || l == h || l == f || l == d);
            btns4[d].BackColor = Color.FromName(colorone);
            selected13 = btns4[d];
            btns4[f].BackColor = Color.FromName(colorone);
            selected14 = btns4[f];
            btns4[h].BackColor = Color.FromName(colorone);
            selected15 = btns4[h];
            btns4[k].BackColor = Color.FromName(colorone);
            selected16 = btns4[k];
            btns4[j].BackColor = Color.FromName(colorone);
            selected17 = btns4[j];
            btns4[l].BackColor = Color.FromName(colorone);
            selected18 = btns4[l];
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int x = rand.Next(255);
            int y = rand.Next(255);
            int z = rand.Next(255);
            for(int i = 0 ; i<18 ; i++)
            {
                if(i == d || i == f || i == h || i == k || i == j || i == l)
                    continue;
                if(count1 < 6)
                {
                    btns4[i].BackColor = Color.FromArgb(r, g, b);
                    btns4[i].Click += Button4_Click;
                    this.Controls.Add(btns4[i]);
                    count1++;
                }else if(count2 < 6)
                {
                    btns4[i].BackColor = Color.FromArgb(x, y, z);
                    btns4[i].Click += Button4_Click;
                    this.Controls.Add(btns4[i]);
                    count2++;
                }
                if(count2 >= 6 && count1 >= 6)
                    break;
            }
            selected13.Click += Selected13_Click;
            this.Controls.Add(selected13);
            selected14.Click += Selected14_Click;
            this.Controls.Add(selected14);
            selected15.Click += Selected15_Click;
            this.Controls.Add(selected15);
            selected16.Click += Selected16_Click;
            this.Controls.Add(selected16);
            selected17.Click += Selected17_Click;
            this.Controls.Add(selected17);
            selected18.Click += Selected18_Click;
            this.Controls.Add(selected18);
        }
        void Step_E()
        {
            lbStage.Text = "مرحله پنجم";
            for (int i = 0;i < 21; i++)
            {
                btns5[i].Visible = true;
            }
            Random rnd5 = new Random();
            int q = rnd5.Next(21);
            int w;
            do
            {
                w = rnd5.Next(21);
            } while (w == q);
            int t;
            do
            {
                t = rnd5.Next(21);
            }while(t == q || t == w);
            int y;
            do
            {
                y = rnd5.Next(21);
            }while (y == q || y == w || y == t);
            int u;
            do
            {
                u = rnd5.Next(21);
            }while(u == q || u == w || u == t || u == y);
            int o;
            do
            {
                o = rnd5.Next(21);
            }while(o == q || o == w || o == t || o == y || o == u);
            int p;
            do
            {
                p = rnd5.Next(21);
            }while(p == q || p == w || p == t || p == y || p == u || p == o);
            btns5[q].BackColor = Color.FromName(colortwo);
            correct1 = btns5[q];
            correct1.Click += Correct1_Click;
            this.Controls.Add(correct1);
            btns5[w].BackColor = Color.FromName(colortwo);
            correct2 = btns5[w];
            correct2.Click += Correct2_Click;
            this.Controls.Add(correct2);
            btns5[t].BackColor = Color.FromName(colortwo);
            correct3 = btns5[t];
            correct3.Click += Correct3_Click;
            this.Controls.Add(correct3); ;
            btns5[y].BackColor = Color.FromName(colortwo);
            correct4 = btns5[y];
            correct4.Click += Correct4_Click;
            this.Controls.Add(correct4);
            btns5[u].BackColor = Color.FromName(colortwo);
            correct5 = btns5[u];
            correct5.Click += Correct5_Click;
            this.Controls.Add(correct5);
            btns5[o].BackColor = Color.FromName(colortwo);
            correct6 = btns5[o];
            correct6.Click += Correct6_Click;
            this.Controls.Add(correct6);
            btns5[p].BackColor = Color.FromName(colortwo);
            correct7 = btns5[p];
            correct7.Click += Correct7_Click;
            this.Controls.Add(correct7);
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int x = rand.Next(255);
            int v = rand.Next(255);
            int z = rand.Next(255);
            for(int i = 0; i < 21; i++)
            {
                if (i == q || i == w || i == t || i == y || i == u || i == o || i == p)
                    continue;
                if(count1 < 7)
                {
                    btns5[i].BackColor = Color.FromArgb(r, g, b);
                    btns5[i].Click += Button5_Click;
                    this.Controls.Add(btns5[i]);
                    count1++;
                }else if(count2 < 7)
                {
                    btns5[i].BackColor = Color.FromArgb(x, v, z);
                    btns5[i].Click += Button5_Click;
                    this.Controls.Add(btns5[i]);
                    count2++;
                }
                if (count1 >= 7 && count2 >= 7)
                    break;
            }
        }
        void Step_F()
        {
            lbStage.Text = "مرحله ششم";
            for (int i = 0; i < 24; i++)
            {
                btns6[i].Visible = true;
            }
            Random rnd6 = new Random();
            int s = rnd6.Next(24);
            int d;
            do
            {
                d = rnd6.Next(24);
            }while(s == d);
            int f;
            do
            {
                f = rnd6.Next(24);
            }while(f == s || f == d);
            int h;
            do
            {
                h = rnd6.Next(24);
            } while (h == f || h == d || h == s);
            int j;
            do
            {
                j = rnd6.Next(24);
            }while(j == h || j == f || j == d || j == s);
            int k;
            do
            {
                k = rnd6.Next(24);
            }while(k == h || k == f || k == d || k == s || k == j);
            int l;
            do
            {
                l = rnd6.Next(24);
            }while (l == f || l == d || l == s || l == j || l == h || l == k);
            int n;
            do
            {
                n = rnd6.Next(24);
            }while(n == f || n == d || n == s || n == j || n == l || n == h || n == k);
            btns6[s].BackColor = Color.FromName(colorthree);
            correct8 = btns6[s];
            correct8.Click += Correct8_Click;
            this.Controls.Add(correct8);
            btns6[d].BackColor = Color.FromName(colorthree);
            correct9 = btns6[d];
            correct9.Click += Correct9_Click;
            this.Controls.Add(correct9);
            btns6[f].BackColor = Color.FromName(colorthree);
            correct10= btns6[f];
            correct10.Click += Correct10_Click;
            this.Controls.Add(correct10);
            btns6[h].BackColor = Color.FromName(colorthree);
            correct11 = btns6[h];
            correct11.Click += Correct11_Click;
            this.Controls.Add(correct11);
            btns6[j].BackColor = Color.FromName(colorthree);
            correct12 = btns6[j];
            correct12.Click += Correct12_Click;
            this.Controls.Add(correct12);
            btns6[k].BackColor = Color.FromName(colorthree);
            correct13 = btns6[k];
            correct13.Click += Correct13_Click;
            this.Controls.Add(correct13);
            btns6[l].BackColor = Color.FromName(colorthree);
            correct14 = btns6[l];
            correct14.Click += Correct14_Click;
            this.Controls.Add(correct14);
            btns6[n].BackColor = Color.FromName(colorthree);
            correct15 = btns6[n];
            correct15.Click += Correct15_Click;
            this.Controls.Add(correct15);
            Random random = new Random();
            int r = random.Next(255);
            int g = random.Next(255);
            int b = random.Next(255);
            int count1 = 0;
            int count2 = 0;
            int x = random.Next(255);
            int z = random.Next(255);
            int v = random.Next(255);
            for(int i = 0;i < 24; i++)
            {
                if (i == s || i == d || i == f || i == h || i == j || i == k || i == l || i == n)
                    continue;
                if(count1 < 8)
                {
                    btns6[i].BackColor = Color.FromArgb(r, g, b);
                    btns6[i].Click += Button6_Click;
                    this.Controls.Add(btns6[i]);
                    count1++;
                }else if(count2 < 8)
                {
                    btns6[i].BackColor = Color.FromArgb(x, z, v);
                    btns6[i].Click += Button6_Click;
                    this.Controls.Add(btns6[i]);
                    count2++;
                }
                if(count1 >= 8 && count2 >= 8)
                    break;
            }
        }
        void Step_G()
        {
            lbStage.Text = "مرحله هفتم";
            for (int i = 0; i < 27; i++)
            {
                btns7[i].Visible = true;
            }
            Random rnd7 = new Random();
            int d = rnd7.Next(18);
            int f;
            do
            {
                f = rnd7.Next(18);
            } while (f == d);
            int h;
            do
            {
                h = rnd7.Next(18);
            } while (h == d || h == f);
            int k;
            do
            {
                k = rnd7.Next(18);
            } while (k == h || k == f || k == d);
            int j;
            do
            {
                j = rnd7.Next(18);
            } while (j == k || j == h || j == f || j == d);
            int l;
            do
            {
                l = rnd7.Next(18);
            } while (l == j || l == k || l == h || l == f || l == d);
            int m;
            do
            {
                m = rnd7.Next(18);
            }while(m == l || m == j || m == k || m == h || m == f || m == d);
            int w;
            do
            {
                w = rnd7.Next(18);
            }while(w == j || w == k || w == h || w == f || w == d || w == l || w == m);
            int u;
            do
            {
                u = rnd7.Next(18);
            }while(u == j || u == k || u == h || u == f || u == d || u == l || u == w || u == l);
            btns7[d].BackColor = Color.FromName(colorone);
            correct16 = btns7[d];
            correct16.Click += Correct16_Click;
            this.Controls.Add(correct16);
            btns7[f].BackColor = Color.FromName(colorone);
            correct17 = btns7[f];
            correct17.Click += Correct17_Click;
            this.Controls.Add(correct17);
            btns7[h].BackColor = Color.FromName(colorone);
            correct18 = btns7[h];
            correct18.Click += Correct18_Click;
            this.Controls.Add(correct18);
            btns7[k].BackColor = Color.FromName(colorone);
            correct19 = btns7[k];
            correct19.Click += Correct19_Click;
            this.Controls.Add(correct19);
            btns7[j].BackColor = Color.FromName(colorone);
            correct20 = btns7[j];
            correct20.Click += Correct20_Click;
            this.Controls.Add(correct20);
            btns7[l].BackColor = Color.FromName(colorone);
            correct21 = btns7[l];
            correct21.Click += Correct21_Click;
            this.Controls.Add(correct21);
            btns7[m].BackColor = Color.FromName(colorone);
            correct22 = btns7[m];
            correct22.Click += Correct22_Click;
            this.Controls.Add(correct22);
            btns7[w].BackColor = Color.FromName(colorone);
            correct23 = btns7[w];
            correct23.Click += Correct23_Click;
            this.Controls.Add(correct23);
            btns7[u].BackColor = Color.FromName(colorone);
            correct24 = btns7[u];
            correct24.Click += Correct24_Click;
            this.Controls.Add(correct24);
            Random rand = new Random();
            int r = rand.Next(255);
            int g = rand.Next(255);
            int b = rand.Next(255);
            int count1 = 0;
            int count2 = 0;
            int x = rand.Next(255);
            int y = rand.Next(255);
            int z = rand.Next(255);
            for(int i = 0; i < 27; i++)
            {
                if (i == d || i == f || i == h || i == k || i == l || i == m || i == w || i == u || i == j)
                    continue;
                if(count1 < 9)
                {
                    btns7[i].BackColor = Color.FromArgb(r, g, b);
                    btns7[i].Click += Button7_Click;
                    this.Controls.Add(btns7[i]);
                    count1++;
                }else if(count2 < 9)
                {
                    btns7[i].BackColor = Color.FromArgb(x, y, z);
                    btns7[i].Click += Button7_Click;
                    this.Controls.Add(btns7[i]);
                    count2++;
                }
                if(count1 >= 9 && count2 >= 9)
                    break;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Defining buttons that contain musical notes
        private void Correct16_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct16)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct16.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if(mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();

                }
            }
        }
        private void Correct17_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct17)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct17.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct16 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct18_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct18)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct18.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct16 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct19_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct19)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct19.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct16 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct20_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct20)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct20.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct16 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct21_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct21)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct21.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct16 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct22_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct22)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct22.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct16 && btns7[i] != correct23 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct23_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct23)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct23.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct16 && btns7[i] != correct24)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct24_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct24)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct24.Visible = false;
                for (int i = 0; i < 27 && remove < 2; i++)
                {
                    if (btns7[i].Visible && btns7[i] != correct17 && btns7[i] != correct18 && btns7[i] != correct19 && btns7[i] != correct20 && btns7[i] != correct21 && btns7[i] != correct22 && btns7[i] != correct23 && btns7[i] != correct16)
                    {
                        btns7[i].Visible = false;
                        remove++;
                    }
                }
                if (mark == 42)
                {
                    MessageBox.Show("You win");
                    MessageBox.Show(Convert.ToString(mark));
                    SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
                    this.Hide();
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
            }
        }
        private void Correct8_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct8)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct8.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false && 
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }

        private void Correct9_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct9)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct9.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct8 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct10_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct10)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct10.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct8 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct11_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct11)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct11.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct8 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct12_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct12)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct12.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct8 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct13_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct13)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct13.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct8 && btns6[i] != correct14 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct14_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct14)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct14.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct8 && btns6[i] != correct15)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct15_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct15)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct15.Visible = false;
                for (int i = 0; i < 24 && remove < 2; i++)
                {
                    if (btns6[i].Visible && btns6[i] != correct9 && btns6[i] != correct10 && btns6[i] != correct11 && btns6[i] != correct12 && btns6[i] != correct13 && btns6[i] != correct14 && btns6[i] != correct8)
                    {
                        btns6[i].Visible = false;
                        remove++;
                    }
                    if (btn76.Visible == false && btn77.Visible == false && btn78.Visible == false && btn79.Visible == false && btn80.Visible == false &&
                        btn81.Visible == false && btn82.Visible == false && btn83.Visible == false && btn84.Visible == false && btn85.Visible == false &&
                        btn86.Visible == false && btn87.Visible == false && btn88.Visible == false && btn89.Visible == false && btn90.Visible == false &&
                        btn91.Visible == false && btn92.Visible == false && btn93.Visible == false && btn94.Visible == false && btn95.Visible == false && btn96.Visible == false && btn97.Visible == false && btn98.Visible == false && btn99.Visible == false)

                        Step_G();
                }
            }
        }
        private void Correct1_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct1)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct1.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct3 && btns5[i] != correct4 && btns5[i] != correct5 && btns5[i] != correct6 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            }
        }
        private void Correct2_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct2)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct2.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct1 && btns5[i] != correct3 && btns5[i] != correct4 && btns5[i] != correct5 && btns5[i] != correct6 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            }
        }
        private void Correct3_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct3)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct3.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct1 && btns5[i] != correct4 && btns5[i] != correct5 && btns5[i] != correct6 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();

                }
            }
        }
        private void Correct4_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct4)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct4.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct3 && btns5[i] != correct1 && btns5[i] != correct5 && btns5[i] != correct6 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            
            }
        }
        private void Correct5_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct5)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct5.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct3 && btns5[i] != correct4 && btns5[i] != correct1 && btns5[i] != correct6 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            
            }
        }
        private void Correct6_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct6)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct6.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct3 && btns5[i] != correct4 && btns5[i] != correct5 && btns5[i] != correct1 && btns5[i] != correct7)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            
            }
        }
        private void Correct7_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == correct7)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                correct7.Visible = false;
                for (int i = 0; i < 21 && remove < 2; i++)
                {
                    if (btns5[i].Visible && btns5[i] != correct2 && btns5[i] != correct3 && btns5[i] != correct4 && btns5[i] != correct5 && btns5[i] != correct6 && btns5[i] != correct1)
                    {
                        btns5[i].Visible = false;
                        remove++;
                    }
                    if (btn55.Visible == false && btn56.Visible == false && btn57.Visible == false && btn58.Visible == false && btn59.Visible == false &&
                        btn60.Visible == false && btn61.Visible == false && btn62.Visible == false && btn63.Visible == false && btn64.Visible == false &&
                        btn65.Visible == false && btn66.Visible == false && btn67.Visible == false && btn68.Visible == false && btn69.Visible == false &&
                        btn70.Visible == false && btn71.Visible == false && btn72.Visible == false && btn73.Visible == false && btn74.Visible == false && btn75.Visible == false)

                        Step_F();
                }
            }
        }
        private void Selected13_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected13)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                selected13.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected14 && btns4[i] != selected15 && btns4[i] != selected16 && btns4[i] != selected17 && btns4[i] != selected18)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                        btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false && 
                        btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                    {
                        Step_E();
                    }
                }
            }
        }
        private void Selected14_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected14)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                selected14.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected13 && btns4[i] != selected15 && btns4[i] != selected16 && btns4[i] != selected17 && btns4[i] != selected18)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                        btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false &&
                        btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                    {
                        Step_E();
                    }
                }
            }
        }
        private void Selected15_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected15)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected15.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected14 && btns4[i] != selected13 && btns4[i] != selected16 && btns4[i] != selected17 && btns4[i] != selected18)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                        btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false &&
                        btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                    {
                        Step_E();
                    }
                }
            }
        }
        private void Selected16_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected16)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected16.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected14 && btns4[i] != selected15 && btns4[i] != selected13 && btns4[i] != selected17 && btns4[i] != selected18)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                        btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false &&
                        btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                    {
                        Step_E();
                    }
                }
            }
        }
        private void Selected17_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected17)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                int remove = 0;
                mark++;
                selected17.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected14 && btns4[i] != selected15 && btns4[i] != selected16 && btns4[i] != selected13 && btns4[i] != selected18)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                        btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false &&
                        btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                    {
                        Step_E();
                    }
                }
            }
        }
        private void Selected18_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected18)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected18.Visible = false;
                for (int i = 0; i < 18 && remove < 2; i++)
                {
                    if (btns4[i].Visible && btns4[i] != selected14 && btns4[i] != selected15 && btns4[i] != selected16 && btns4[i] != selected17 && btns4[i] != selected13)
                    {
                        btns4[i].Visible = false;
                        remove++;
                    }
                    
                }
                if (btn37.Visible == false && btn38.Visible == false && btn39.Visible == false && btn40.Visible == false && btn41.Visible == false &&
                    btn42.Visible == false && btn43.Visible == false && btn44.Visible == false && btn45.Visible == false && btn46.Visible == false &&
                    btn47.Visible == false && btn48.Visible == false && btn49.Visible == false && btn50.Visible == false && btn51.Visible == false && btn52.Visible == false && btn53.Visible == false && btn54.Visible == false)
                {
                    Step_E();
                }
            }
        }
        private void Selected8_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected8)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected8.Visible = false;
                for (int i = 0; i < 15 && remove < 2; i++)
                {
                    if (btns3[i].Visible && btns3[i] != selected9 && btns3[i] != selected10 && btns3[i] != selected11 && btns3[i] != selected12)
                    {
                        btns3[i].Visible = false;
                        remove++;
                    }

                }
                if (btn22.Visible == false && btn23.Visible == false && btn24.Visible == false && btn25.Visible == false && btn26.Visible == false && 
                    btn27.Visible == false && btn28.Visible == false && btn29.Visible == false && btn30.Visible == false && btn31.Visible == false &&
                    btn32.Visible == false && btn33.Visible == false && btn34.Visible == false && btn35.Visible == false && btn36.Visible == false)
                {
                    Step_D();
                }

            }
        }
        private void Selected9_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected9)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected9.Visible = false;
                for (int i = 0; i < 15 && remove < 2; i++)
                {
                    if (btns3[i].Visible && btns3[i] != selected8 && btns3[i] != selected10 && btns3[i] != selected11 && btns3[i] != selected12)
                    {
                        btns3[i].Visible = false;
                        remove++;
                    }

                }
                if (btn22.Visible == false && btn23.Visible == false && btn24.Visible == false && btn25.Visible == false && btn26.Visible == false &&
                    btn27.Visible == false && btn28.Visible == false && btn29.Visible == false && btn30.Visible == false && btn31.Visible == false && 
                    btn32.Visible == false && btn33.Visible == false && btn34.Visible == false && btn35.Visible == false && btn36.Visible == false)
                {
                    Step_D();
                }

            }
        }
        private void Selected10_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected10)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected10.Visible = false;
                for (int i = 0; i < 15 && remove < 2; i++)
                {
                    if (btns3[i].Visible && btns3[i] != selected8 && btns3[i] != selected9 && btns3[i] != selected11 && btns3[i] != selected12)
                    {
                        btns3[i].Visible = false;
                        remove++;
                    }

                }
                if (btn22.Visible == false && btn23.Visible == false && btn24.Visible == false && btn25.Visible == false && btn26.Visible == false &&
                    btn27.Visible == false && btn28.Visible == false && btn29.Visible == false && btn30.Visible == false && btn31.Visible == false &&
                    btn32.Visible == false && btn33.Visible == false && btn34.Visible == false && btn35.Visible == false && btn36.Visible == false)
                {
                    Step_D();
                }

            }
        }
        private void Selected11_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected11)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected11.Visible = false;
                for (int i = 0; i < 15 && remove < 2; i++)
                {
                    if (btns3[i].Visible && btns3[i] != selected8 && btns3[i] != selected10 && btns3[i] != selected9 && btns3[i] != selected12)
                    {
                        btns3[i].Visible = false;
                        remove++;
                    }

                }
                if (btn22.Visible == false && btn23.Visible == false && btn24.Visible == false && btn25.Visible == false && btn26.Visible == false && 
                    btn27.Visible == false && btn28.Visible == false && btn29.Visible == false && btn30.Visible == false && btn31.Visible == false &&
                    btn32.Visible == false && btn33.Visible == false && btn34.Visible == false && btn35.Visible == false && btn36.Visible == false)
                {
                    Step_D();
                }

            }
        }
        private void Selected12_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected12)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected12.Visible = false;
                for (int i = 0; i < 15 && remove < 2; i++)
                {
                    if (btns3[i].Visible && btns3[i] != selected8 && btns3[i] != selected10 && btns3[i] != selected11 && btns3[i] != selected9)
                    {
                        btns3[i].Visible = false;
                        remove++;
                    }

                }
                if (btn22.Visible == false && btn23.Visible == false && btn24.Visible == false && btn25.Visible == false && btn26.Visible == false &&
                    btn27.Visible == false && btn28.Visible == false && btn29.Visible == false && btn30.Visible == false && btn31.Visible == false &&
                    btn32.Visible == false && btn33.Visible == false && btn34.Visible == false && btn35.Visible == false && btn36.Visible == false)
                {
                    Step_D();
                }

            }
        }
        private void Selected4_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected4)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected4.Visible = false;
                for (int i = 0; i < 12 && remove < 2; i++)
                {
                    if (btns2[i].Visible && btns2[i] != selected6 && btns2[i] != selected5 && btns2[i] != selected7)
                    {
                        btns2[i].Visible = false;
                        remove++;
                    }
                    if(btn10.Visible == false && btn12.Visible == false && btn13.Visible == false && btn14.Visible == false && btn15.Visible == false && 
                        btn16.Visible == false && btn17.Visible == false && btn18.Visible == false && btn19.Visible == false && btn20.Visible == false &&
                        btn21.Visible == false)
                    {
                        Step_C();
                    }
                }

            }
        }

        private void Selected5_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected5)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected5.Visible = false;
                for (int i = 0; i < 12 && remove < 2; i++)
                {
                    if (btns2[i].Visible && btns2[i] != selected6 && btns2[i] != selected4 && btns2[i] != selected7)
                    {
                        btns2[i].Visible = false;
                        remove++;
                    }
                    if (btn10.Visible == false && btn12.Visible == false && btn13.Visible == false && btn14.Visible == false && btn15.Visible == false &&
                        btn16.Visible == false && btn17.Visible == false && btn18.Visible == false && btn19.Visible == false && btn20.Visible == false &&
                        btn21.Visible == false)
                    {
                        Step_C();
                    }

                }

            }
        }
        private void Selected6_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected6)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++; 
                mark++;
                int remove = 0;
                selected6.Visible = false;
                for (int i = 0; i < 12 && remove < 2; i++)
                {
                    if (btns2[i].Visible && btns2[i] != selected4 && btns2[i] != selected5 && btns2[i] != selected7)
                    {
                        btns2[i].Visible = false;
                        remove++;
                    }
                    if (btn10.Visible == false && btn12.Visible == false && btn13.Visible == false && btn14.Visible == false && btn15.Visible == false &&
                        btn16.Visible == false && btn17.Visible == false && btn18.Visible == false && btn19.Visible == false && btn20.Visible == false &&
                        btn21.Visible == false)
                    {
                        Step_C();
                    }
                }
            }
        }
        private void Selected7_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected7)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected7.Visible = false;
                for (int i = 0; i < 12 && remove < 2; i++)
                {
                    if (btns2[i].Visible && btns2[i] != selected6 && btns2[i] != selected5 && btns2[i] != selected4)
                    {
                        btns2[i].Visible = false;
                        remove++;
                    }
                    if (btn10.Visible == false && btn12.Visible == false && btn13.Visible == false && btn14.Visible == false && btn15.Visible == false && 
                        btn16.Visible == false && btn17.Visible == false && btn18.Visible == false && btn19.Visible == false && btn20.Visible == false &&
                        btn21.Visible == false)
                    {
                        Step_C();
                    }
                }
            }
        }
        private void Selected1_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected1)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                int remove = 0;
                selected1.Visible = false;
                for (int i = 0; i < 9 && remove < 2; i++)
                {
                    if (BTNS[i].Visible && BTNS[i] != selected2 && BTNS[i] != selected3)
                    {
                        BTNS[i].Visible = false;
                        remove++;
                    }
                }
                if (btn1.Visible == false && btn2.Visible == false && btn3.Visible == false && btn4.Visible == false && btn5.Visible == false &&
                    btn6.Visible == false && btn7.Visible == false && btn8.Visible == false && btn9.Visible == false)
                {
                    Step_B();
                }
            }

        }
        private void Selected2_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected2)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                selected2.Visible = false;
                int remove = 0;
                for (int i = 0; i < 9 && remove < 2; i++)
                {
                    if (BTNS[i].Visible && BTNS[i] != selected1 && BTNS[i] != selected3)
                    {
                        BTNS[i].Visible = false;
                        remove++;
                    }
                }
                if (btn1.Visible == false && btn2.Visible == false && btn3.Visible == false && btn4.Visible == false && btn5.Visible == false &&
                    btn6.Visible == false && btn7.Visible == false && btn8.Visible == false && btn9.Visible == false)
                {
                    Step_B();
                }

            }
        }
        private void Selected3_Click(object sender, EventArgs e)
        {
            Button clickbutton = sender as Button;
            if (clickbutton == selected3)
            {
                audioFile = new AudioFileReader("D:\\Notes\\" + fileNames[Index[curr]]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFile);
                waveOut.Play();
                Thread.Sleep(600);
                curr++;
                mark++;
                selected3.Visible = false;
                int remove = 0;
                for (int i = 0; i < 9 && remove < 2; i++)
                {
                    if (BTNS[i].Visible && BTNS[i] != selected1 && BTNS[i] != selected2)
                    {
                        BTNS[i].Visible = false;
                        remove++;
                    }

                }
                if (btn1.Visible == false && btn2.Visible == false && btn3.Visible == false && btn4.Visible == false && btn5.Visible == false &&
                    btn6.Visible == false && btn7.Visible == false && btn8.Visible == false && btn9.Visible == false)
                {
                    Step_B();
                }

            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Buttons that are wrong in the game and their messages
        private void Button_Click(object sender, EventArgs e)
        {
            btn1.Visible = btn2.Visible = btn3.Visible = btn4.Visible = btn5.Visible = btn6.Visible = btn7.Visible = false;
            btn8.Visible = btn9.Visible = false;
            for (int i = 0; i < 9; i++)
            {
               BTNS[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                btns2[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                btns3[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 18; i++)
            {
                btns4[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            for(int i = 0; i< 21; i++)
            {
                btns5[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                btns6[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 27; i++)
            {
                btns7[i].Visible = false;
            }
            MessageBox.Show(Convert.ToString(mark));
            SaveOrUpdateScore(Form4.currentUserNationalCode, mark);
            this.Hide();
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
    }
}
