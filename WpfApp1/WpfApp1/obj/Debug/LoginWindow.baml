   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  LoginWindow��5   	   $	��250��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�66   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   �    
additional#��[  6   �� 5   
   $��Resources/school_logo.png��6   $��10q�5      $
��Left=�6   �� 5   
   $��0��6   $��Software product��6!   $��Center=�69   $��Center=�5      #��[  6/   $��20(�5      $
��Bold"�6"   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      ��   item_textblock#��[ 6   $��1��6@   $��Login��6M   $
��20 0q�5      $��Center=�6&   $	��100��6A   �� 5      -   5         ��Name$ TbLogin��5      $��1��6'   $	��200��67   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   .+�5      �� #��[ 6   $��2��6@   $��0��5       $��Password��6(   $
��20 0q�68   $��Center=�6F   $	��100��6a   G� 5!      -   5         G�Name$ TbPass��5!      $��30��6*   $	��200��66   5"      �� 5#   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   .+�5$      �� -   5         ��Name$ BtnOk��5%      $	��100��5$      $��30��6!   $
��Okey��6-   5%   $   �� 5&      -   5        $ 	BtnCancel��5'      $	��100��5&      $��30��6!   $��Cancel��6-   5'   (   5(      5)      5*      