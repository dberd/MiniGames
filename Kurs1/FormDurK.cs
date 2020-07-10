using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs1
{
  
  public partial class FormDurK : Form
  {
    bool hod,f=true,g=true,l=true,u=true;
    const int n = 36;
    int hm = 0, hp = 0,kolkp=0;
    public Karts[] masb=new Karts[n];
    public Karts CheckB = new Karts();
    public List<Karts> HandK = new List<Karts>();
    int KozZn;
    char KozMast;
    public Button MeB = new Button(), PrB = new Button(), ContB = new Button(), SayB = new Button(), ForPB = new Button(),NoB = new Button();
    
    public FormDurK()
    {

      
      InitializeComponent();
      {
        masb[0]=new Karts() { B=P6B, Mast = 'P' };
        masb[1] = new Karts() { B = P7B, Mast='P' };
        masb[2] = new Karts() { B = P8B, Mast = 'P' };
        masb[3] = new Karts() { B = P9B, Mast = 'P' };
        masb[4] = new Karts() { B = P10B, Mast = 'P' };
        masb[5] = new Karts() { B = PVB, Mast = 'P' };
        masb[6] = new Karts() { B = PDB, Mast = 'P' };
        masb[7] = new Karts() { B = PKB, Mast = 'P' };
        masb[8] = new Karts() { B = PTB, Mast = 'P' };
        //Piq
        masb[9] = new Karts() { B = B6B, Mast = 'B' };
        masb[10] = new Karts() { B = B7B,Mast = 'B' };
        masb[11] = new Karts() { B = B8B, Mast = 'B' };
        masb[12] = new Karts() { B = B9B, Mast = 'B' };
        masb[13] = new Karts() { B = B10B, Mast = 'B' };
        masb[14] = new Karts() { B = BVB, Mast = 'B' };
        masb[15] = new Karts() { B = BDB, Mast = 'B' };
        masb[16] = new Karts() { B = BKB, Mast = 'B' };
        masb[17] = new Karts() { B = BTB, Mast = 'B' };
        //Bub
        masb[18] = new Karts() { B = K6B, Mast = 'K' };
        masb[19] = new Karts() { B = K7B, Mast = 'K' };
        masb[20] = new Karts() { B = K8B, Mast = 'K' };
        masb[21] = new Karts() { B = K9B, Mast = 'K' };
        masb[22] = new Karts() { B = K10B, Mast = 'K' };
        masb[23] = new Karts() { B = KVB, Mast = 'K' };
        masb[24] = new Karts() { B = KDB, Mast = 'K' };
        masb[25] = new Karts() { B = KKB, Mast = 'K' };
        masb[26] = new Karts() { B = KTB, Mast = 'K' };
        //Krest
        masb[27] = new Karts() { B = H6B, Mast = 'H' };
        masb[28] = new Karts() { B = H7B, Mast = 'H' };
        masb[29] = new Karts() { B = H8B, Mast = 'H' };
        masb[30] = new Karts() { B = H9B, Mast = 'H' };
        masb[31] = new Karts() { B = H10B, Mast = 'H' };
        masb[32] = new Karts() { B = HVB, Mast = 'H' };
        masb[33] = new Karts() { B = HDB, Mast = 'H' };
        masb[34] = new Karts() { B = HKB, Mast = 'H' };
        masb[35] = new Karts() { B = HTB, Mast = 'H' };
        //Heart
      }//Все карты в массив
      for(int i=0;i<n;i++)
      {

        switch (masb[i].B.Name[1])
        {
          case 'V':
            masb[i].Zn = 11;
            break;
          case 'D':
            masb[i].Zn = 12;
            break;
          case 'K':
            masb[i].Zn = 13;
            break;
          case 'T':
            masb[i].Zn = 14;
            break;
          case '1':
            masb[i].Zn = 10;
            break;
          default:
            masb[i].Zn = Convert.ToInt32(masb[i].B.Name[1])-48;
            break;
        }
      }//Добавление свойств
      for (int i = 0; i < n; i++)
      {
        masb[i].B.Click +=B_Click1;
      }//Выбор козыря
      
      FormClosing += Programm_Closing;
      MainLabel.Text = "Выберите козыря";
      MainLabel.ForeColor = Color.Fuchsia;
      
      ZaverB.Visible = false;
      TakeB.Visible = false;
      BackB.Visible = false;
      TakeB.Click += TakeB_Click;
      ZaverB.Click += ZaverB_Click;

      NoB.Click += NoB_Click;
      {
        PrB.Click += PrB_Click;
        MeB.Click += MeB_Click;
      }// Нажатие "Я" или "Противник"
      
    }

    private void ContB_Click(object sender, EventArgs e)
    {
      SayB.Visible = false;
      ContB.Visible = false;

      if (MainLabel.Text == "Противник смухлевал(Вы можете  сказать ему об этом, или продолжить игру)")
      {
        foreach(Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
          {
            ph.B.FlatAppearance.BorderColor = Color.DarkRed;
          }
          ph.B.Enabled = true;
        }
        TakeB_Func();
        
      }
      else
        Boi();
    }

    private void SayB_Click(object sender, EventArgs e)
    {
      SayB.Visible = false;
      ContB.Visible = false;
      if (MainLabel.Text == "Противник смухлевал(Вы можете сказать ему об этом, или продолжить игру)")
      {
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
          {
            ph.B.FlatAppearance.BorderColor = Color.Black;

            hp--;

          }
          ph.B.Enabled = true;
        }

        ChangeLabel();
      }
      if (MainLabel.Text == "Противник смухлевал(Вы можете  сказать ему об этом, или продолжить игру)")
      {
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
          {
            ph.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
            hp--;

          }
          ph.B.Enabled = true;
        }
        NoB.Visible = true;
        MainLabel.Text = "Какие карты еще подкинул противник?";
      }
    }
   
    void ChangeLabel()
    {
      int kolvph = 0, kolrph = 0, kolbmh=0,kolgmh=0;
     
      foreach(Karts ph in masb)
      {
        if (ph.B.Visible == true)
          kolvph++;
        if (ph.B.FlatAppearance.BorderColor == Color.Red)
          kolrph++;

      }
      foreach(Karts mh in HandK)
      {
        if (mh.B.FlatAppearance.BorderColor == Color.Blue)
          kolbmh++;
        if (mh.B.FlatAppearance.BorderColor == Color.Green)
          kolgmh++;
      }
      if(kolvph==35 || HandK.Count<6)
      {
        MainLabel.Text = "Какие карты оказались у Вас в руке?";
        MainLabel.ForeColor = Color.Orange;
        return;
      }//Первый набор карт
      if(kolvph==29 && g)
      {
        if (f)
        {
          f = false;
          MainLabel.Text = "Кто ходит первым?";

          MainLabel.ForeColor = Color.Blue;
        }//Чей ход первый
        else
        {
          if (hod == true)
          {
            MainLabel.Text = "Ваш ход";
            MainLabel.ForeColor = Color.Green;
          }
          else
          {
            MainLabel.Text = "Ход противника";
            MainLabel.ForeColor = Color.Red;
          }
          g = false;
        }//Когда решили кто ходит первый
      }

      if (!g)
      {
        if (hod == false)// че делать с кнопкой взять карты
        {
          TakeB.Text = "Взять карты";
        }
        else
        {
          
          TakeB.Text = "Противник взял карты";
        }//Кнопка взять карты


        if(hod==true)
        {
          if(hp==-1)
          {
            MainLabel.Text = "Противник бьёт";
            MainLabel.ForeColor = Color.Red;
          }
          if (hp == 0)
          {
            if (kolbmh != 0 || kolgmh==0)
            {
              MainLabel.Text = "Ваш ход";
              MainLabel.ForeColor = Color.Green;
            }
            else
            {
              MainLabel.Text = "Вам нечего больше подкинуть (если вы играете честно)";
              MainLabel.ForeColor = Color.DarkBlue;
            }
          }
        }//Если сейчас мой ход
        if(hod==false)
        {
          if (hp == 0)
          {
            MainLabel.Text = "Ход противника";
            MainLabel.ForeColor = Color.Red;
          }
          if (hp == 1)
          {
            if (kolrph == 0  )
            {
              MainLabel.Text = "Вы бьёте";
              MainLabel.ForeColor = Color.Green;
            }
            else
            {
              MainLabel.Text = "Вам нечем больше бить (если вы играете честно)";
              MainLabel.ForeColor = Color.DarkBlue;
            }
          }
        }//Если сейчас ход противника
      }
      MainLabel.Text +=  "kolkp=" + kolkp;
    }
      
    bool Check(Karts button,Karts CheckB)
    {
      int koldg = 0;
      if (hod == false && hp == 1)
      {
        
        
        foreach (Karts ph1 in masb)
        {
          if ((ph1.B.FlatAppearance.BorderColor==Color.Red|| ph1.B.FlatAppearance.BorderColor == Color.DarkGray|| ph1.B.FlatAppearance.BorderColor == Color.Gray)&&ph1.Zn == button.Zn && ph1!=button ||masb.Count(ob=>ob.B.FlatAppearance.BorderColor!=SystemColors.ButtonFace && ob.B.FlatAppearance.BorderColor != Color.Black) ==1)
          {
            return true;
          }
        }
        foreach (Karts mh in HandK)
        {
          if (mh.B.FlatAppearance.BorderColor == Color.Green && mh.Zn == button.Zn)
          {
            return true;
          }
        }
          
        return false;
      }//Проверка правильно ли противник подкинул нам карту
      if (hod == true && hp == 0)
      {
        foreach(Karts ph in masb)
        {
          if(ph.B.FlatAppearance.BorderColor==Color.Red)
          {
            if (CheckB.Mast != KozMast && ph.Zn > CheckB.Zn && ph.Mast == CheckB.Mast ||
                  CheckB.Mast != KozMast && ph.Mast == KozMast ||
                  ph.Mast == KozMast && CheckB.Mast == KozMast && CheckB.Zn < ph.Zn)
              return true;
            else
              return false;
          }
        }
      }//Проверка правильно ли он побил
      return true;
        
      
    }
    void Boi()
    {
      if (hp ==1 && hod==false)
      {


        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
          {
            
            foreach (Karts mh in HandK)
            {
              if (ph.Mast != KozMast && ph.Zn < mh.Zn && ph.Mast == mh.Mast ||
                  ph.Mast != KozMast && mh.Mast == KozMast ||
                  ph.Mast == KozMast && mh.Mast == KozMast && mh.Zn > ph.Zn)
              {

                if (mh.B.FlatAppearance.BorderColor != Color.Green)
                {
                  mh.B.FlatAppearance.BorderColor = Color.Blue;
                  ph.B.FlatAppearance.BorderColor = Color.Gray;
                }
              }
            }
            break;
          }
        }


        foreach (Karts ph in masb)
        {
          ph.B.Enabled = false;
        }
        foreach (Karts mh in HandK)
        {
          mh.B.Enabled = true;

        }

      }//Подсказка ЧЕМ можно ПОБИТЬ
      if (hp == 0 && hod == true)
      {
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
          { 
            foreach (Karts mh in HandK)
            {
              if (ph.Zn == mh.Zn && mh.B.FlatAppearance.BorderColor!=Color.Green)
                mh.B.FlatAppearance.BorderColor = Color.Blue;
            }
          }
        }
        foreach (Karts mh in HandK)
        {
          if(mh.B.FlatAppearance.BorderColor== Color.Green)
          {
            foreach (Karts mh1 in HandK)
            {
              if (mh != mh1 && mh.Zn == mh1.Zn && mh1.B.FlatAppearance.BorderColor!=Color.Green)
                mh1.B.FlatAppearance.BorderColor = Color.Blue;
            }
          }
        }
        foreach (Karts mh in HandK)
        {
          mh.B.Enabled = true;
        }//Включили руку
        foreach (Karts ph in masb)
        {
          ph.B.Enabled = false;

        }//Выключили стол
      }//Подсказка ЧТО можно ПОДКИНУТЬ(после хода противника)
      if (hp == 0 && hod == false)
      {
        foreach (Karts mh in HandK)
        {
          if (mh.B.FlatAppearance.BorderColor == Color.Blue)
            mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;

        }
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Gray)
            ph.B.FlatAppearance.BorderColor = Color.DarkGray;
        }

        foreach (Karts mh in HandK)
        {
          mh.B.Enabled = false;
        }//Выключили руку
        foreach (Karts ph in masb)
        {
          ph.B.Enabled = true;

        }//Включили стол
      }//Если я только что побил карту противника(после моего хода)
      if(hp==-1 && hod==true)
      {
        foreach (Karts mh in HandK)
        {
          if (mh.B.FlatAppearance.BorderColor == Color.Blue)
            mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;

        }
        foreach(Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red)
            ph.B.FlatAppearance.BorderColor = Color.DarkGray;
        }
        foreach (Karts mh in HandK)
        {
          mh.B.Enabled = false;
        }
        foreach (Karts ph in masb)
        {
          ph.B.Enabled = true;

        }
      }//Если я только что подкинул карту противнику(после моего хода)
      
      ChangeLabel();

    }
    bool TakeB_Func()
    {

      if (hod == false)
      {
        if (masb.Count(ob => ob.B.Visible == true) + HandK.Count == 35 &&
        masb.Count(ob => ob.B.FlatAppearance.BorderColor == Color.DarkGray || ob.B.FlatAppearance.BorderColor == Color.Red) < 5 ||
        masb.Count(ob => ob.B.Visible == true) + HandK.Count < 35 &&
        masb.Count(ob => ob.B.FlatAppearance.BorderColor == Color.DarkGray || ob.B.FlatAppearance.BorderColor == Color.Red) < 6)
        {


          


          MainLabel.Text = "Какие карты еще подкинул противник?";

          NoB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
          NoB.Cursor = Cursors.Hand;
          NoB.FlatStyle = FlatStyle.Flat;
          NoB.Visible = true;
          NoB.UseVisualStyleBackColor = false;

          NoB.Text = "Всё";
          Hand.Controls.Add(NoB, Hand.ColumnCount - (int)(HandK.Count * 0.5), 0);
          return false;
        }
      }
      else
      {
        
        hp = 0;
        Boi();
        MainLabel.Text = "Какие карты вы еще подкинете?";
        NoB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
        NoB.Cursor = Cursors.Hand;
        NoB.FlatStyle = FlatStyle.Flat;
        NoB.Visible = true;
        NoB.UseVisualStyleBackColor = false;

        NoB.Text = "Всё";
        Hand.Controls.Add(NoB, Hand.ColumnCount - (int)(HandK.Count * 0.5), 0);
        return false;
      }
      return true;
    }
    private void TakeB_Click(object sender, EventArgs e)
    {
      TakeB.Visible = false;
      ZaverB.Visible = false;
      
      if (TakeB_Func())
      {
        NoB_Click(null, null);
      }
      else
      {
        if (hod == false)
        {
          foreach (Karts mh in HandK)
          {
            if (mh.B.FlatAppearance.BorderColor == Color.Blue)
              mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
          }
        }
        if (hod == true)
        {
          foreach (Karts ph in masb)
          {
            ph.B.Enabled = false;

          }
          foreach (Karts mh in HandK)
          {
            mh.B.Enabled = true;
          }
        }
        else
        {
          foreach (Karts ph in masb)
          {
            ph.B.Enabled = true;

          }
          foreach (Karts mh in HandK)
          {
            mh.B.Enabled = false;
          }
        }
      }
    }//Кнопка взять карты
    void EndF()
    {
      
      if(masb.Count(ob=>ob.B.Visible==true)+1-kolkp<=6-HandK.Count && kolkp>=6&& HandK.Count<6)
      {
        
      }//1 случай: карты нужны мне и не нужны противнику 
      
      if(masb.Count(ob => ob.B.Visible == true) + 1 - kolkp <= 6 - kolkp && HandK.Count>=6 && kolkp<6)
      {
        foreach(Karts ph in masb)
        {
          if(ph.Zn==KozZn&& ph.Mast==KozMast)
          {
            ph.B.Visible = true;
          }
          if (ph.B.FlatAppearance.BorderColor != Color.Black)
          {
            ph.B.FlatAppearance.BorderColor = Color.Black;
            kolkp++;
          }
        }
      }//2 случай: карты нужны противнику и не нужны мне
      
      if(masb.Count(ob => ob.B.Visible == true) + 1 - kolkp <=  - kolkp && HandK.Count < 6&& kolkp<6)
      {

      }//3 случай: когда карты нужны и мне и ему
    }
    private void NoB_Click(object sender, EventArgs e)
    {
      int kolphv = 0;
      ZaverB.Visible = true;
      TakeB.Visible = true;
      EndF();
      if (hod == false)
      {

        foreach (Karts ph in masb)
        {

          if (ph.B.FlatAppearance.BorderColor==Color.DarkRed||ph.B.FlatAppearance.BorderColor == Color.Red || ph.B.FlatAppearance.BorderColor == Color.Gray || ph.B.FlatAppearance.BorderColor == Color.DarkGray)
          {
            ph.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
            ph.B.Visible = false;
            HandK.Add(new Karts());



            Hand.ColumnCount += 1;
            Hand.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            Hand.Controls.Add(HandK[HandK.Count - 1].B, HandK.Count, 1);

            HandK[HandK.Count - 1].B.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
            HandK[HandK.Count - 1].B.BackColor = Color.Transparent;
            HandK[HandK.Count - 1].B.BackgroundImage = ph.B.BackgroundImage;
            HandK[HandK.Count - 1].B.BackgroundImageLayout = ImageLayout.Zoom;
            HandK[HandK.Count - 1].B.Cursor = Cursors.Hand;
            HandK[HandK.Count - 1].B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
            HandK[HandK.Count - 1].B.FlatAppearance.BorderSize = 7;
            HandK[HandK.Count - 1].B.FlatAppearance.MouseOverBackColor = Color.Transparent;
            HandK[HandK.Count - 1].B.FlatStyle = FlatStyle.Flat;
            HandK[HandK.Count - 1].B.Visible = true;
            HandK[HandK.Count - 1].B.UseVisualStyleBackColor = false;
            HandK[HandK.Count - 1].Zn = ph.Zn;
            HandK[HandK.Count - 1].Mast = ph.Mast;
            HandK[HandK.Count - 1].B.Click += B_Click31;
          }



        }//Добавление карт в руку
        foreach (Karts mh in HandK)
        {
          if (mh.B.FlatAppearance.BorderColor == Color.Blue || mh.B.FlatAppearance.BorderColor == Color.Green)
          {
            mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
          }
        }//Убираем лишние рамки
        foreach (Karts mh in HandK)
        {
          mh.B.Enabled = false;
        }// Выключаем руку

        foreach (Karts ph in masb)
        {
          ph.B.Enabled = true;

        }//Включаем стол



      }
      else
      {
        foreach (Karts mh in HandK)
        {
          if (mh.B.FlatAppearance.BorderColor == Color.Green)
          {
            foreach (Karts ph in masb)
            {
              if (ph.Zn == mh.Zn && ph.Mast == mh.Mast)
              {
                ph.B.Visible = true;
                ph.B.FlatAppearance.BorderColor = Color.Black;
                kolkp++;
              }
              if (ph.B.Visible == true)
                kolphv++;
            }
          }
        }//Добавление карт из руки на стол
        for (int i = 0; i < HandK.Count; i++)
        {
          Karts mh = HandK[i];
          if (mh.B.FlatAppearance.BorderColor == Color.Green)
          {


            Hand.ColumnStyles[Hand.GetColumn(mh.B)].Width = 0;
            Hand.Controls.Remove(mh.B);
            HandK.Remove(mh);
            i--;
          }
          if (mh.B.FlatAppearance.BorderColor == Color.Blue)
          {
            mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
          }
        }//Удаление карт из руки
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.DarkGray|| ph.B.FlatAppearance.BorderColor==Color.Red)
          {
            ph.B.FlatAppearance.BorderColor = Color.Black;
          }
        }//Окраска 100-процентных карт со стола
        if (HandK.Count < 6)
        {
          foreach (Karts ph in masb)
          {
            ph.B.Click -= B_Click32;
            ph.B.Click += B_Click2;
            if (ph.B.FlatAppearance.BorderColor == Color.Black)
              ph.B.Enabled = false;
            else
              ph.B.Enabled = true;
          }
          foreach (Karts mh in HandK)
            mh.B.Enabled = false;

          if (kolphv < 12 - HandK.Count)
          {
            ForPB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
              | AnchorStyles.Left)
              | AnchorStyles.Right);
            ForPB.Cursor = Cursors.Hand;
            ForPB.FlatStyle = FlatStyle.Flat;
            ForPB.Visible = true;
            ForPB.UseVisualStyleBackColor = false;
            ForPB.Text = "Остальные карты противнику";
            Hand.Controls.Add(SayB, Hand.ColumnCount - (int)(HandK.Count * 0.5), 0);
            Kozir.Click += B_Click2;
          }//Конец игры
        }
      }
      NoB.Visible = false;
      hp = 0;
      ChangeLabel();
    }

    public void ZaverB_Click(object sender, EventArgs e)
    {
      int kolphv = 0;
      EndF();
      if (hp == 0)
      {
        foreach (Karts ph in masb)
        {
          if (ph.B.FlatAppearance.BorderColor == Color.Red || ph.B.FlatAppearance.BorderColor == Color.Gray || ph.B.FlatAppearance.BorderColor == Color.DarkGray)
          {
            ph.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
            ph.B.Visible = false;
            kolkp--;
          }
          if (ph.B.Visible == true)
            kolphv++;//подсчет карт на столе
        }
        for (int i = 0; i < HandK.Count; i++)
        {
          Karts mh = HandK[i];
          if (mh.B.FlatAppearance.BorderColor == Color.Green)
          {
            

            Hand.ColumnStyles[Hand.GetColumn(mh.B)].Width = 0 ;
            Hand.Controls.Remove(mh.B);
            HandK.Remove(mh);
            i--;
          }
          if(mh.B.FlatAppearance.BorderColor == Color.Blue)
          {
            mh.B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
          }
        }//Удаление карт из руки
        if (HandK.Count < 6)
        {
          
          foreach (Karts ph in masb)
          {
            ph.B.Enabled = true;
            ph.B.Click += B_Click2;

            ph.B.Click -= B_Click32;
            if (ph.B.FlatAppearance.BorderColor == Color.Black)
              ph.B.Enabled = false;
          }
          foreach (Karts mh in HandK)
            mh.B.Enabled = false;

        
        }
        //смена хода
        else
        {
          if (hod == true)
          {

            foreach (Karts mh in HandK)
            {
              mh.B.Enabled = false;
            }
            foreach (Karts ph in masb)
            {
              ph.B.Enabled = true;
            }
          }
          else
          {
            foreach (Karts mh in HandK)
            {
              mh.B.Enabled = true;
            }
            foreach (Karts ph in masb)
            {
              ph.B.Enabled = false;
            }
          }
        }

        //Смена хода
        if (hod == false)
          hod = true;
        else
          hod = false;
        

        ChangeLabel();
      }
      
     

      
    }//Кнопка завершения хода

    private void MeB_Click(object sender, EventArgs e)
    {
      foreach(Karts mh in HandK)
      {
        mh.B.Enabled = true;

      }//Добавление моего хода картам в руке 
      foreach (Karts ph in masb)
        ph.B.Click += B_Click32;
      PrB.Visible = false;
      MeB.Visible = false;
      ZaverB.Visible = true;
      TakeB.Visible = true;
      hod = true;
      ChangeLabel();

    }// Первый ход мой

    private void PrB_Click(object sender, EventArgs e)
    {
      foreach(Karts ph in masb)
      {
        ph.B.Enabled = true;
        ph.B.Click += B_Click32;
      }//Все карты в руке, можно добавлять ход противника, и активировать стол
      TakeB.Visible = true;
      PrB.Visible = false;
      MeB.Visible = false;
      ZaverB.Visible = true;
      hod = false;
      ChangeLabel();
      
      
    }//Первый ход противника


    private void B_Click32(object sender, EventArgs e)
    {
      
     
      
      var button = (Button)sender;
     
      hp++;
      button.FlatAppearance.BorderColor = Color.Red;
      button.FlatAppearance.BorderSize = 3;
      Karts ob = null;
      foreach (Karts ph in masb)
      {
        if (ph.B == button)
        {
          ob = ph;
          break;
        }
      }



      if (MainLabel.Text == "Какие карты еще подкинул противник?")
        hp = 1;
      if (Check(ob, CheckB))
      {

        if (MainLabel.Text != "Какие карты еще подкинул противник?")
          Boi();
        else
        {
          button.FlatAppearance.BorderColor = Color.DarkRed;

        }
      }
      else
      {
        if (MainLabel.Text == "Какие карты еще подкинул противник?")
          MainLabel.Text = "Противник смухлевал(Вы можете  сказать ему об этом, или продолжить игру)";
        else
          MainLabel.Text = "Противник смухлевал(Вы можете сказать ему об этом, или продолжить игру)";
        NoB.Visible = false;
        foreach (Karts ph in masb)
          ph.B.Enabled = false;
        SayB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
              | AnchorStyles.Left)
              | AnchorStyles.Right);
        SayB.Cursor = Cursors.Hand;
        SayB.FlatStyle = FlatStyle.Flat;
        SayB.Visible = true;
        SayB.UseVisualStyleBackColor = false;
        SayB.Text = "Сказать ему";
        Hand.Controls.Add(SayB, Hand.ColumnCount - (int)(HandK.Count * 0.7), 0);

        Hand.Controls.Add(ContB, Hand.ColumnCount - (int)(HandK.Count * 0.4), 0);
        ContB.Dock = DockStyle.Bottom;
        ContB.Cursor = Cursors.Hand;
        ContB.UseVisualStyleBackColor = false;
        ContB.Visible = true;
        ContB.FlatStyle = FlatStyle.Flat;
        ContB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
              | AnchorStyles.Left)
              | AnchorStyles.Right);
        ContB.Text = "Продолжить игру";
        SayB.Click += SayB_Click;
        ContB.Click += ContB_Click;
      }
      
     
    }//Ход противника

    private void B_Click31(object sender, EventArgs e)
    {
      
      hp--;
      var button = (Button)sender;

      
      button.FlatAppearance.BorderColor = Color.Green;
      button.FlatAppearance.BorderSize = 3;

      if (MainLabel.Text != "Какие карты вы еще подкинете?")
      {
        if (hod == true)
        {
          CheckB = HandK.Find(bu => bu.B == button);

        }
        Boi();
      }
      else
        TakeB_Func();
     
    }//Мой ход

    public class Karts
    {
      public Button B=new Button();

      public int Zn=new int();
      public char Mast=new char();
    }//Добавление свойств для карт (масть и номер)


    private void B_Click2(object sender, EventArgs e)
    {

      
      Karts button = new Karts() {B= (Button)sender };
      button.Mast = button.B.Name[0];
        switch (button.B.Name[1])
        {
          case 'V':
            button.Zn = 11;
            break;
          case 'D':
            button.Zn = 12;
            break;
          case 'K':
            button.Zn = 13;
            break;
          case 'T':
            button.Zn = 14;
            break;
          case '1':
            button.Zn = 10;
            break;
          default:
            button.Zn = Convert.ToInt32(button.B.Name[1])-48;
            break;
        }//Добавление свойств
      int kolphv = 0;
      var but = (Button)sender;
      but.Visible = false;
      foreach(Karts ph in masb)
      {
        if (ph.B.Visible == true)
          kolphv++;
      }
      EndF();
      if (HandK.Count< 6)
      {

        
        if (HandK.Count ==0)
        {
          Hand.ColumnStyles[Hand.ColumnCount-1 ].Width = 0;
          
        }
        HandK.Add(new Karts());
        Hand.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        Hand.ColumnCount += 1;
        Hand.Controls.Add(HandK[HandK.Count-1].B, Hand.ColumnCount-1, 1);
        
        HandK[HandK.Count-1].B.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right);
        HandK[HandK.Count-1].B.BackColor = Color.Transparent;
        HandK[HandK.Count-1].B.BackgroundImage = button.B.BackgroundImage;
        HandK[HandK.Count-1].B.BackgroundImageLayout = ImageLayout.Zoom;
        HandK[HandK.Count-1].B.Cursor = Cursors.Hand;
        HandK[HandK.Count-1].B.FlatAppearance.BorderColor = SystemColors.ButtonFace;
        HandK[HandK.Count-1].B.FlatAppearance.BorderSize = 7;
        HandK[HandK.Count-1].B.FlatAppearance.MouseOverBackColor = Color.Transparent;
        HandK[HandK.Count-1].B.FlatStyle = FlatStyle.Flat;
        HandK[HandK.Count-1].B.Visible = true;
        HandK[HandK.Count-1].B.UseVisualStyleBackColor = false;
        HandK[HandK.Count-1].Zn = button.Zn;
        HandK[HandK.Count-1].Mast = button.Mast;
        HandK[HandK.Count - 1].B.Click += B_Click31;
        
        if(kolphv-kolkp==0)
        {
          Kozir.Enabled = true;
        }




      }//Добавление карт в руку

      HandK[HandK.Count - 1].B.Enabled = false;// Отключаем руку 
      
      if (HandK.Count == 6)
      {
        
        foreach(Karts ph in masb)
        {
          ph.B.Click -= B_Click2;
          ph.B.Enabled = false;
        }// Отключаем стол и убираем 2 событие
        int t = 0;
        foreach(Karts ph in masb)
        {
          if(ph.B.Visible==true)
          {
            t++;
          }
        }//Считаем сколько карт на столе
        
        if (l)
        {
          kolkp = 6;
          l = false;
          ChangeLabel();
          MeB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
          MeB.Cursor = Cursors.Hand;
          MeB.FlatStyle = FlatStyle.Flat;
          MeB.Visible = true;
          MeB.UseVisualStyleBackColor = false;
          MeB.Text = "Вы";
          Hand.Controls.Add(MeB, 3, 0);

          Hand.Controls.Add(PrB, 6, 0);
          PrB.Dock = DockStyle.Bottom;
          PrB.Cursor = Cursors.Hand;
          PrB.UseVisualStyleBackColor = false;
          PrB.Visible = true;
          PrB.FlatStyle = FlatStyle.Flat;
          PrB.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom)
                | AnchorStyles.Left)
                | AnchorStyles.Right);
          PrB.Text = "Противник";
          return;
        }//Если я только набрал старотовую руку
        else
        {
          if(hod==false)
          {

            foreach (Karts ph in masb)
            {
              ph.B.Enabled = true;
              ph.B.Click += B_Click32;
            }

          }
          else
          {

            foreach (Karts mh in HandK)
            {
              mh.B.Enabled=true;
            }
            foreach (Karts ph in masb)
            {
              ph.B.Enabled = false;
              ph.B.Click += B_Click32;
            }
          }
          
        }
        if(kolkp<6)
        {
          if (kolphv < 6 - kolkp)
          {
            foreach (Karts ph in masb)
              ph.B.FlatAppearance.BorderColor = Color.Black;
            if (Kozir.Visible == true)
            {
              kolkp = 1 + kolphv;
              foreach(Karts ph in masb)
              {
                if(ph.Mast==KozMast&& ph.Zn==KozZn)
                {
                  ph.B.Visible = true;
                  ph.B.FlatAppearance.BorderColor = Color.Black;
                  Kozir.Visible = false;
                }
              }
            }
            else
            {
              kolkp = kolphv;
            }

          }
          else
            kolkp = 6;
        }
        ChangeLabel();
      }//Первый ход

    }//Добавление карт в стартовую руку(после этого все карты отключены)

    private void Programm_Closing(object sender, CancelEventArgs e)
    {
      e.Cancel = true;
      Environment.Exit(0);
    }//X закрывает всё


    private void B_Click1(object sender, EventArgs e)
    {
      Kozir.Visible = true;
      var button = (Button)sender;
      KozMast = button.Name[0];
      switch (button.Name[1])
      {
        case 'V':
          KozZn = 11;
          break;
        case 'D':
          KozZn = 12;
          break;
        case 'K':
          KozZn = 13;
          break;
        case 'T':
          KozZn = 14;
          break;
        case '1':
          KozZn = 10;
          break;
        default:
          KozZn = Convert.ToInt32(button.Name[1]) - 48;
          break;
      }//Добавление свойств
      
      button.Visible = false;
      
      Kozir.BackgroundImage = button.BackgroundImage;
      for (int i = 0; i < n; i++)
      {
        masb[i].B.Click -= B_Click1;
        masb[i].B.Click += B_Click2;
      }//Козырь выбран, это событие можно отключать и добавлять следующее
      ChangeLabel();
      BackB.Visible = true;
    }//Выбор козыря

  }
}
