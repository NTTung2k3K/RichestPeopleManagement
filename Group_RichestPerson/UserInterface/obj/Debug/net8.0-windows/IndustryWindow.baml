   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5   	   "    UserInterface.IndustryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UserInterface     5   	   -   5          � Title$  IndustryWindow��5   	   $	��480��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   
�������.��5	      � .+�5
   
   �� $��Industry Management��6   
����� �$
��Bold"�6D   $��30(�6V   $��Center=�6d   $��0,10,0,0q�6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.533,0.057&�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ IndustryDataGrid��5         AutoGenerateColumns$ False��6-   $
��Left=�6I   $	��294��6d   $��
10,130,0,0q�6q   $	��Top=�6�   $	��600��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
IndustryId��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *
IndustryId+  5      $ Industry Name��6%   $	 350 6<    6H   �� *IndustryName+5      �� 5   
   
�������
���   �$��1q�68   $
��Left=�6L   $��53��6g   $��	10,65,0,0q�6s   $	��Top=�6�   $	��600��6�   �� 5   
   -   5        	 ��Name$	 SearchButton��5      $��Search��6'   $
��Left=�68   $��
400,79,0,0q�6S   $	��Top=�6g   $��26��6   $��74��6�   $ 0.614,0.363&�6�   
����������#a8741a$
��Bold"�6�   6�   �� 5   
   -   5        $	 CreateButton��5      $��Create��6'   $
��Left=�68   $��
666,95,0,0q�6S   $	��Top=�6g   $ 0.337,1.071&�6   $��41��6�   $��91��6�   
����������#1ABC9C$
��Bold"�6�   6�   �� 5   
   -   5        $	 UpdateButton��5      $��Update��6'   $
��Left=�68   $��666,169,0,0q�6S   $	��Top=�6h   $��38��6�   $��91��6�   
���   �
��� ���$
��Bold"�6�   6�   �� 5   
   -   5        $	 DeleteButton��5      $��Delete��6'   $
��Left=�68   $��666,244,0,0q�6S   $	��Top=�6h   $��41��6�   $��91��6�   $ 	0.5,1.731&�6�   
�������
���  ��$
��Bold"�6�   6�   �� 5   
   -   5        $	 
BackButton��5      $
��Back��6%   $
��Left=�64   $��666,313,0,0q�6O   $	��Top=�6d   $��41��6|   $��91��6�   
�������
����i��$
��Bold"�6�   �� 5   
   -   5        $	 
QuitButton��5      $
��Quit��6%   $
��Left=�64   $��666,375,0,0q�6O   $	��Top=�6d   $��39��6|   $��91��6�   
�������
���   �$
��Bold"�6�   �� 5   
   $��13(�6   $��Industry Name��6   $
��Left=�66   $��	36,76,0,0q�6Q   $	��Top=�6d   $ 3.174,1.229&�6|   $��30��6�   $	��100��6�   
����  �$
��Bold"�6�   �� 5   
   -	   5        
 ��Name$
 IndustryNameTextBox��5      $
��Left=�6/   $��
141,82,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��205��6�   $��19��6�   �� 5   
   -
   5        $	 ResetButton��5      $��Reset��6&   $
��Left=�66   $��
499,79,0,0q�6Q   $	��Top=�6e   $��26��6}   $��74��6�   $ 0.614,0.363&�6�   
����������#581845$
��Bold"�6�   6�   5      5      