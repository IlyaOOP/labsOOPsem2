   M S B A M L   `   `   `  ����?  ;lab8, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab8lab8  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	       lab8.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:lab8     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��255* �6   �� 5      $
��538* �6    � RowDefinitions 5   
   �� 5      $
��103* �6   �� 5      $	��37* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��objgrid��5      $
��Left=�6"   $	��Top=�6>      AutoGenerateColumns . $��0��6q   6~     5   
   -   5        $��authgrid��5      $
��Left=�6#   $	��Top=�6@    . $��0��6s   $��1��6�   6�   �� 5   
   -   5        $#��Добавить запись��5      $��Right=�6+   $	��Top=�6G   $��19��6t   $��96��6�   $��1��6�   �� 5   
   -   5        $��photobox��5      $
��Left=�6    $	��110��6;   $��	0,0.2,0,0q�6H   $	��Top=�6[   $	��110��6s   $��1��6   �� 5   
   -   5        $��update��5      $
��Left=�6"   $��	0,290,0,0q�6=   $��2��6P   $	��Top=�6a   $��75��6y   6�   �� 5   
   -   5        $��delete Selected Author��5      $��1��62   $
��Left=�6B   $��1��6^   $��Stretch=�6k   6�   �� 5   
   -   5        $��delete Selected Book��5      $��1��60   $��Center=�6@   $��1��6^   $��Stretch=�6k   6�   5      5      