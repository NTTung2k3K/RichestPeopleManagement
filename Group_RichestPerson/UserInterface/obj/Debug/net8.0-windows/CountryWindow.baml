   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5   	   !    UserInterface.CountryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UserInterface     5   	   -   5          � Title$  CountryWindow��5   	   $	��500��5	   	   $	��800��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
�������.��5      � .+�5   
   �� $��Country Management��6   
����� �$
��Bold"�5      $��30(�5      $��Center=�5      $��0,10,0,0q�5      $	��Top=�5       J� RenderTransformOrigin$ 0.533,0.057&�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CountryDataGrid��5         AutoGenerateColumns$ False��5      $
��Left=�5      $	��294��5      $��
10,130,0,0q�5      $	��Top=�5      $	��600��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	CountryId��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 5    %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5!   %   �� *	CountryId+  5"      $ Country Name��6%   $	 350 5#   %    5$   %   �� *CountryName+5&      �� 5'   
   
�������
���   �$��1q�5)      $
��Left=�5*      $��53��5+      $��	26,65,0,0q�5,      $	��Top=�5-      $	��568��5.      �� 5/   
   -   5        	 ��Name$	 SearchButton��5/      $��Search��50      $
��Left=�51      $��
376,79,0,0q�52      $	��Top=�53      $��26��54      $��74��55      
����������#a8741a$ 0.614,0.363&�57      58      �� 59   
   -   5        $	 CreateButton��59      $��Create��5:      $
��Left=�5;      $��688,105,0,0q�5<      $	��Top=�5=      $ 0.337,1.071&�5>      $��41��5?      $��91��5@      
����������#1ABC9C$
��Bold"�5A   >   5B      �� 5C   
   -   5        $	 UpdateButton��5C      $��Update��5D      $
��Left=�5E      $��688,179,0,0q�5F      $	��Top=�5G      $��38��5H      $��91��5I      
���   �
��� ���5K      �� 5L   
   -   5        $	 DeleteButton��5L      $��Delete��5M      $
��Left=�5N      $��688,254,0,0q�5O      $	��Top=�5P      $��41��5Q      $��91��5R      $ 	0.5,1.731&�5S      
�������
���  ��$
��Bold"�5T   :   5U      �� 5V   
   -   5        $	 
BackButton��5V      $
��Back��5W      $
��Left=�5X      $��688,323,0,0q�5Y      $	��Top=�5Z      $��41��5[      $��91��5\      
�������
����i��$
��Bold"�5]   >   5^      �� 5_   
   -   5        $	 
QuitButton��5_      $
��Quit��5`      $
��Left=�5a      $��688,385,0,0q�5b      $	��Top=�5c      $��39��5d      $��91��5e      
�������
���   �$
��Bold"�5f   <   5g      �� 5h   
   $��13(�6   $��Country Name��5i      $
��Left=�5j      $��	36,76,0,0q�5k      $	��Top=�5l      $ 3.174,1.229&�5m      $��30��5n      $	��100��5o      
����  �$
��Bold"�5p   "   �� 5q   
   -	   5        
 ��Name$
 CountryNameTextBox��5q      $
��Left=�5r      $��
141,82,0,0q�5s       �� TextWrapping$
 Wrap=�5t      $�� ��5u      $	��Top=�5v      $	��205��5w      $��19��5x      �� 5y   
   -
   5        $	 ResetButton��5y      $��Reset��5z      $
��Left=�5{      $��
472,79,0,0q�5|      $	��Top=�5}      $��26��5~      $��74��5      $ 0.614,0.363&�5�      
����������#581845$
��Bold"�5�   >   5�      5�      5�      