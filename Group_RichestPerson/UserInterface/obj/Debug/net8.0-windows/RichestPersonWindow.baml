   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5   	   '    !UserInterface.RichestPersonWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UserInterface     5   	   -   5          � Title$  RichestPersonWindow��5   	   $	��500��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>   
�������.��5	      � .+�5
   
   �� $��Richest People Management��6   
����� �$
��Bold"�6J   $��30(�6\   $��Center=�6j   $��0,10,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.533,0.057&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ RichestPeopleDataGrid��5         AutoGenerateColumns$ False��62   $
��Left=�6N   $	��294��6i   $��
24,161,0,0q�6v   $	��Top=�6�   $	��641��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ RichestPersonId��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *RichestPersonId+  5      $
 Rank��6%   $ 50 63    6>   �� *Rank+  5      $
 Name��6%   $	 120 63    6?   �� *Name+  5      $	 Age��6%   $ 50 62    6=   �� *Age+  5      $ NetWorth��6%   $ 80 67    6B   �� *
NetWorth+  5      $ 	CountryId��6%   $ 80 68    6C   �� *	CountryId+  5      $ CountryName��6%   $	 100 6:    6F   �� *Country.CountryName+  5      $ 
IndustryId��6%   $ 80 69    6D   �� *
IndustryId+  5      $ IndustryName��6%   $	 100 6;    6G   �� *Industry.IndustryName+5      �� 5   
   
�������
���   �$��1q�68   $
��Left=�6L   $��81��6g   $��	20,65,0,0q�6s   $	��Top=�6�   $	��645��6�   �� 5   
   -   5        	 ��Name$	 SearchButton��5      $��Search��6'   $
��Left=�68   $��
472,78,0,0q�6S   $	��Top=�6g   $��26��6   $��74��6�   $ 0.614,0.363&�6�   
����������#a8741a$
��Bold"�6  �� 5   
   -   5        $	 CreateButton��5      $��Create��6'   $
��Left=�68   $��688,105,0,0q�6S   $	��Top=�6h   $ 0.337,1.071&�6�   $��41��6�   $��91��6�   
����������#1ABC9C$
��Bold"�6  �� 5   
   -   5        $	 UpdateButton��5      $��Update��6'   $
��Left=�68   $��688,179,0,0q�6S   $	��Top=�6h   $��38��6�   $��91��6�   
���   �
��� ���$
��Bold"�6�   �� 5   
   -   5        $	 DeleteButton��5      $��Delete��6'   $
��Left=�68   $��688,254,0,0q�6S   $	��Top=�6h   $��41��6�   $��91��6�   $ 	0.5,1.731&�6�   
�������
���  ��$
��Bold"�6�   �� 5   
   -   5        $	 
BackButton��5      $
��Back��6%   $
��Left=�64   $��688,323,0,0q�6O   $	��Top=�6d   $��41��6|   $��91��6�   
�������
����i��$
��Bold"�6�   �� 5   
   -   5        $	 
QuitButton��5      $
��Quit��6%   $
��Left=�64   $��688,385,0,0q�6O   $	��Top=�6d   $��39��6|   $��91��6�   
�������
���   �$
��Bold"�6�   �� 5   
   $��13(�6   $
��Name��6   $
��Left=�6-   $��
258,76,0,0q�6H   $	��Top=�6\   $ 3.174,1.229&�6t   $��30��6�   $��50��6�   
����  �$
��Bold"�6�   �� 5    
   $��13(�6   $
��Rank��6   $
��Left=�6-   $��	33,76,0,0q�6H   $	��Top=�6[   $ 0.377,0.587&�6s   $��28��6�   $��43��6�   
����  �$
��Bold"�6�   �� 5!   
   -	   5        
 ��Name$
 RankTextBox��5!      $
��Left=�6'   $��	81,82,0,0q�6B    �� TextWrapping$
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��136��6�   $��19��6�   �� 5"   
   -
   5        $
 NameTextBox��5"      $
��Left=�6'   $��
308,82,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��135��6�   $��19��6�   �� 5#   
   -   5        $	 ResetButton��5#      $��Reset��6&   $
��Left=�66   $��
575,78,0,0q�6Q   $	��Top=�6e   $��26��6}   $��74��6�   $ 0.614,0.363&�6�   
����������#581845$
��Bold"�6�   6�   	� 5$   
   -   5         	�Name$ TechnologyRiadio��5$   +   $��
Technology��6   $
��Left=�6E   $��325,119,0,0q�6`   $	��Top=�6u   	� 5%   
   -   5        $ UnitedStatesRadio��5%      $��United States��61   $
��Left=�6I   $��176,119,0,0q�6d   $	��Top=�6y   	� 5&   
   -   5        $ ChinaRiadio��5&      $��China��6+   $
��Left=�6;   $��
60,118,0,0q�6V   $	��Top=�6j   	� 5'   
   -   5        $ FashionAndRetailRadio��5'   3   $��Fashion and Retail��6   $
��Left=�6R   $��445,119,0,0q�6m   $	��Top=�6�   5)      5*      