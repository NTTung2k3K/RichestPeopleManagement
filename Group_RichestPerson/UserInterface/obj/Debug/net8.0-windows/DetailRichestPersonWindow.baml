   M S B A M L   `   `   `  ����H  DUserInterface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:UserInterfaceUserInterface  5   	   -    'UserInterface.DetailRichestPersonWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:UserInterface     5   	   -   5          � Title$  DetailRichestPersonWindow��5   	   $	��380��6+   $	��600��68    � WindowStartupLocation$ CenterScreen=�6D   
�������.��5	      � $��	-2,2,2,-4q�6   .+�5
   
   �� -   5         ��Name$ TitileLabel��5
      $��Add Richest Person��6%   
����� �$
��Bold"�6X   $��30(�6j   $
��Left=�6x   $��
172,10,0,0q�6�   $	��Top=�6�   $��45��6�   �� 5   
   -   5         ��Name$ 
SaveButton��5      $
��Save��6%   $
��Left=�64   $��495,162,0,0q�6O   $	��Top=�6d    J� RenderTransformOrigin$ 0.182,0.062&�6|   $��37��6�   $��73��6�   
����������#1ABC9C$
��Bold"�6�   6�   �� 5   
   -   5        $ CloseButton��5      $��Close��6&   $
��Left=�66   $��495,237,0,0q�6Q   $	��Top=�6f   $��39��6~   $��73��6�   
�������
���   �$
��Bold"�6�   6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
79,124,0,0q�6:   $	��Top=�6N   $��32��6f   $��64��6r   $
��Bold"�6}   �� 5   
   -   5         ��Name$ NameTextBox��5      $
��Left=�6'   $��185,130,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��256��6�   $��20��6�   �� 5   
   $	��Age��6   $
��Left=�6   $��
79,166,0,0q�69   $	��Top=�6M   $��32��6e   $��48��6q   $
��Bold"�6|   �� 5   
   -   5        $ 
AgeTextBox��5      $
��Left=�6&   $��185,170,0,0q�6A   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��256��6�   $��22��6�   �� 5   
   $��NetWorth��6   $
��Left=�6#   $��
79,202,0,0q�6>   $	��Top=�6R   $��32��6j   $��95��6v   $
��Bold"�6�   �� 5   
   -   5        $ NetWorthTextBox��5      $
��Left=�6+   $��185,206,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��256��6�   $��22��6�   �� 5   
   $��Country��6   $
��Left=�6"   $��
79,240,0,0q�6=   $	��Top=�6Q   $��32��6i   $��79��6u   $
��Bold"�6�   �� 5   
   $��Industry��6   $
��Left=�6#   $��
79,282,0,0q�6>   $	��Top=�6R   $��32��6j   $��81��6v   $
��Bold"�6�   �� 5   
   -   5         ��Name$ IndustryCombobox��5      $
��Left=�6-   $��185,286,0,0q�6H   $	��Top=�6]   $	��256��6u   $��28��6�   �� 5   
   -	   5        $ CountryCombobox��5      $
��Left=�6,   $��185,243,0,0q�6G   $	��Top=�6\   $	��256��6t   $��27��6�   �� 5   
   -
   5        $ IdLabel��5      $��Id��6!   $
��Left=�6.   $
��Bold"�6I   $��
274,61,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ IdValueLabel��5      $	��123��6&   
���  ��$
��Bold"�6E   $
��Left=�6W   $��
300,61,0,0q�6r   $	��Top=�6�   �� 5   
   -   5        $ 	RankLabel��5      $
��Rank��6#   $
��Left=�62   $
��Bold"�6M   $��
262,87,0,0q�6`   $	��Top=�6t   $ 1.173,0.479&�6�   �� 5   
   -   5        $ RankValueLabel��5      $	��123��6(   
���  ��$
��Bold"�6G   $
��Left=�6Y   $��
300,87,0,0q�6t   $	��Top=�6�   $ 0.856,0.387&�6�   5      5      