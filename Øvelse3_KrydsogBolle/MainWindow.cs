using System;
using Gtk;


public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    bool player = true;
    // Hvilken spiller det er (true/false) - (X/O).

    public string PlayerName()
    {
        string player_name = "";

        if (player == true)
        {
            player_name = "O";
        }
        else
        {
            player_name = "X";
        }
        return player_name;
    }
    // Tager fat i "player" variablen, og returnere "X" eller "O" alt efter hvilken spiller har taget den sidste tur.
    // Er omvendt fra "player" variablen da værdien er blevet ændret ved trykket.

    int flag = 0;
    // Er spillet vundet? 0 = stadig igang; 1 = vundet; -1 = draw.

    string b1_value = "1";
    string b2_value = "2";
    string b3_value = "3";
    string b4_value = "4";
    string b5_value = "5";
    string b6_value = "6";
    string b7_value = "7";
    string b8_value = "8";
    string b9_value = "9";
    // Disse tal bliver brugt som pladsholder (havde de været tomme, vil "CheckWin()" resultere i -1 (draw) fra start).

    bool b1_pressed = false;
    bool b2_pressed = false;
    bool b3_pressed = false;
    bool b4_pressed = false;
    bool b5_pressed = false;
    bool b6_pressed = false;
    bool b7_pressed = false;
    bool b8_pressed = false;
    bool b9_pressed = false;
    // Her lyttes der til hvorvidt en knap er trykket på (bruges til at vurdere hvorvidt der er et draw i CheckWin().

    protected int CheckWin()
    {
        #region Horzontal Winning Condtion
        // Winning Condition: First Row
        if (b1_value == b2_value && b2_value == b3_value)
        {
            return 1;
        }
        // Winning Condition: Second Row
        else if (b4_value == b5_value && b5_value == b6_value)
        {
            return 1;
        }
        // Winning Condition: Third Row
        else if (b7_value == b8_value && b8_value == b9_value)
        {
            return 1;
        }
        #endregion
        #region vertical Winning Condtion
        // Winning Condition: First Column
        else if (b1_value == b4_value && b4_value == b7_value)
        {
            return 1;
        }
        // Winning Condition: Second Column
        else if (b2_value == b5_value && b5_value == b8_value)
        {
            return 1;
        }
        // Winning Condition: Third Column
        else if (b3_value == b6_value && b6_value == b9_value)
        {
            return 1;
        }
        #endregion
        #region Diagonal Winning Condition
        else if (b1_value == b5_value && b5_value == b9_value)
        {
            return 1;
        }
        else if (b3_value == b5_value && b5_value == b7_value)
        {
            return 1;
        }
        #endregion

        #region Checking For Draw
        // Hvis alle værdierne indeholder "X" eller "O" står spillerne lige
        
        else if (b1_pressed == true && b2_pressed == true && b3_pressed == true && b4_pressed == true && b5_pressed == true && b6_pressed == true && b7_pressed == true && b8_pressed == true && b9_pressed == true)
        {
            return -1;
        }
        #endregion
        else
        {
            return 0;
        }
    }

    public void ClearButtons()
    {
        button1.Label = "    ";
        button2.Label = "    ";
        button3.Label = "    ";
        button4.Label = "    ";
        button5.Label = "    ";
        button6.Label = "    ";
        button7.Label = "    ";
        button8.Label = "    ";
        button9.Label = "    ";
        b1_pressed = false;
        b2_pressed = false;
        b3_pressed = false;
        b4_pressed = false;
        b5_pressed = false;
        b6_pressed = false;
        b7_pressed = false;
        b8_pressed = false;
        b9_pressed = false;
        b1_value = "1";
        b2_value = "2";
        b3_value = "3";
        b4_value = "4";
        b5_value = "5";
        b6_value = "6";
        b7_value = "7";
        b8_value = "8";
        b9_value = "9";
    }
    // Resetter knapper og dertilhørende værdier for at klargøre spillet til en ny runde.
    // Ideelt havde denne funktion tilhørt en knap i et eksternt vindue der prompter om lukning eller nyt spil (mangler viden). 



    protected void b1OnClick(object sender, EventArgs e)
    {
        if (player == true && button1.Label != "O")
        {
            button1.Label = "X";
            b1_value = "X";
            b1_pressed = true;
            player = false;
        } else if (button1.Label != "X")
        {
            button1.Label = "O";
            b1_value = "O";
            b1_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            string winning_player = PlayerName();
            ClearButtons();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
    }

    protected void b2OnClick(object sender, EventArgs e)
    {
        if (player == true && button2.Label != "O")
        {
            button2.Label = "X";
            b2_value = "X";
            b2_pressed = true;
            player = false;
        }
        else if (button2.Label != "X")
        {
            button2.Label = "O";
            b2_value = "O";
            b2_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
    }

    protected void b3OnClick(object sender, EventArgs e)
    {
        if (player == true && button3.Label != "O")
        {
            button3.Label = "X";
            b3_value = "X";
            b3_pressed = true;
            player = false;
        }
        else if (button3.Label != "X")
        {
            button3.Label = "O";
            b3_value = "O";
            b3_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
    }

    protected void b4OnClick(object sender, EventArgs e)
    {
        if (player == true && button4.Label != "O")
        {
            button4.Label = "X";
            b4_value = "X";
            b4_pressed = true;
            player = false;
        }
        else if (button4.Label != "X")
        {
            button4.Label = "O";
            b4_value = "O";
            b4_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
    }

    protected void b5OnClick(object sender, EventArgs e)
    {
        if (player == true && button5.Label != "O")
        {
            button5.Label = "X";
            b5_value = "X";
            b5_pressed = true;
            player = false;
        }
        else if (button5.Label != "X")
        {
            button5.Label = "O";
            b5_value = "O";
            b5_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }

        if (flag == 1 || flag == -1)
        {
            Application.Quit();
            //Virker ikke, mangler syntaks til at lukke programmet
        }
    }

    protected void b7OnClick(object sender, EventArgs e)
    {
        if (player == true && button7.Label != "O")
        {
            button7.Label = "X";
            b7_value = "X";
            b7_pressed = true;
            player = false;
        }
        else if (button7.Label != "X")
        {
            button7.Label = "O";
            b7_value = "O";
            b7_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }


    }

    protected void b8OnClick(object sender, EventArgs e)
    {
        if (player == true && button8.Label != "O")
        {
            button8.Label = "X";
            b8_value = "X";
            b8_pressed = true;
            player = false;
        }
        else if (button8.Label != "X")
        {
            button8.Label = "O";
            b8_value = "O";
            b8_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            ClearButtons();
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            ClearButtons();
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
    }

    int NumberOfClickB09 = 0;
    // Bruges i b9OnClick da der her er to mulige udfald ved klik på knappen.

    protected void b9OnClick(object sender, EventArgs e)
    {
        
        ++NumberOfClickB09;
        switch (NumberOfClickB09)
        {
            case 1:
                // Første klik sætter et "X" eller "O".
                if (player == true && button9.Label != "O")
                {
                    button9.Label = "X";
                    b9_value = "X";
                    b9_pressed = true;
                    player = false;
                }
                else if (button9.Label != "X")
                {
                    button9.Label = "O";
                    b9_value = "O";
                    b9_pressed = true;
                    player = true;
                }

                flag = CheckWin();
                if (flag == 1)
                {
                    ClearButtons();
                    string winning_player = PlayerName();
                    button5.Label = (winning_player + " " + "is the winner!");
                    button9.Label = "Play again!";
                    button7.Label = "Exit";
                }
                else if (flag == -1)
                {
                    ClearButtons();
                    button5.Label = "Its a draw!";
                    button9.Label = "Play again!";
                    button7.Label = "Exit";
                }
                break;
            case 2:
                // Andet klik resetter spillet
                if (flag == 1 || flag == -1)
                {
                    ClearButtons();
                }
                NumberOfClickB09 = 0;
                break;
        }
    }
    

    protected void b6OnClick(object sender, EventArgs e)
    {
        if (player == true && button6.Label != "O")
        {
            button6.Label = "X";
            b6_value = "X";
            b6_pressed = true;
            player = false;
        }
        else if (button6.Label != "X")
        {
            button6.Label = "O";
            b6_value = "O";
            b6_pressed = true;
            player = true;
        }

        flag = CheckWin();
        if (flag == 1)
        {
            string winning_player = PlayerName();
            button5.Label = (winning_player + " " + "is the winner!");
            button9.Label = "Play again!";
            button7.Label = "Exit";
        }
        else if (flag == -1)
        {
            button5.Label = "Its a draw!";
            button9.Label = "Play again!";
            button7.Label = "Exit";

            // Ændringerne af buttonX.Label, værdierne brugt i CheckWin() samt skift af spiller kunne med fordel være bygget som funktioner.
        }
    }
}
