   M S B A M L   `   `   `  ����A  =lab4-5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab4_5lab4_5  5          lab4_5.UserControl1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:lab4_5     5      -   5        $��	myelement��5        � Triggers  5
      :� 5   
    :� RoutedEvent$ Loaded��6   [�5      �� 5      .��5      �� .��5      ��  �� TargetProperty$ 
Fill.Color�6)    �� 
TargetName$ e1��6P    �� From$	 redX�5      	 �� To$
 blueX�6(    g� AutoReverse .  g� Duration$ 0:0:3D�5   )    g� RepeatBehavior$ Forever��5   )   �� 5      $ 
Fill.Color�6)   $ e2��6P   $
 blueX�5      $	 redX�6)    . $ 0:0:3D�5   )   $ Forever��5   )   5      5      5      .��5      � $	��100��6   $��50��6   	 � ColumnDefinitions	 5    
   �� 5!      $��50 �6   �� 5"      $��50 �6   .+�5$   
   �� -   5        
 ��Name$
 e1��5$      $��50��6    $��50��6+   
���  ��$��0��6B   6T   �� 5%   
   -   5        $
 e2��5%      $��50��6    $��50��6+   
����  �$��1��6C   5&      5'      