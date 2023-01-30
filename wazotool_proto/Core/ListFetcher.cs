using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//[ WAZO ] //
using System.IO;
using Microsoft.Win32;
using wazotool_proto.MVVM.View;
using wazotool_proto.MVVM.ViewModel;
using System.Windows;

namespace wazotool_proto.Core
{
    internal class ListFetcher
    {


        //INITIALIZE BO2 VARS
        private int? T6_COUNT;
        private string? T6_ZM_ALIASES;
        private string? T6_ZM_FOLDERS;
        private string? T6_FOLDERS;
        private string? appDataLoc;
        private string? q;


        private string error_msg = "Mod installation folder has not been selected by the user.\nPlease choose the right installation folder after closing this message!";
        private string insta_succ = "Current folder updated successfully!\n";
        private string insta_fail = "No updates made to the folder:\n";
        
        //OF BROWSER INSTANCE
        OpenFileDialog ODFCHOOSE = new OpenFileDialog();
        /// <summary>
        /// create a button to pop up the ofdialog.
        /// set each initalization thru button
        /// </summary>

        BO2View d = new BO2View();
        public void fillListBO2()
        {
            //define appdata
            appDataLoc = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            
            //define T6
            T6_FOLDERS = Path.Combine(appDataLoc + @"\Plutonium\Storage\t6");
            
            //get all the dirs from "T6_FOLDERS"
            string[] bo2Dirs = Directory.GetDirectories(T6_FOLDERS);

            //define new instance of the list
            
            //fill the list
            for( int i = 0; i < bo2Dirs.Length; i++)
            {
                if(!d.lstBo2Mods.Items.Contains(bo2Dirs[ i ] ) )
                {
                    d.lstBo2Mods.Items.Add(bo2Dirs[i]);
                }

                //if t6 already contains a same named folda
                else
                {
                    //create a msgbox quiz "YES;NO" if the user wants to override previous folder with more recent one.
                    //keep the old folder upon clicking "NO"

                    q = "Do you want to update the folder called " + bo2Dirs[ i ].ToString() +
                        "\n\nThis will only update the folder with missing features that came out with a more recent update.";

                    MessageBoxResult question_protocol = MessageBox.Show(q, "Overwrite Protocol", MessageBoxButton.YesNo);
                
                    if( question_protocol == MessageBoxResult.Yes)
                    {
                        d.lstBo2Mods.Items.Add(bo2Dirs[i]);
                        MessageBox.Show(insta_succ + "\nDirectory:   " + bo2Dirs[i].ToString() );
                    }

                    else
                    {
                        MessageBox.Show( insta_fail + "\nDirectory:   " + bo2Dirs [ i ].ToString() );
                    }
                
                
                }
            }

        }
    }
}





    

