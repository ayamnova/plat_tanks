   M S B A M L   `   `   `  ����R  NG-FinalProject-Ladnerka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:G_FinalProject_LadnerkaG_FinalProject_Ladnerka  5   	   (    "G_FinalProject_Ladnerka.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:G_FinalProject_Ladnerka     5   	   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5   	   -   5          � Title$  Tanks��5	   	   $	��350��6   $	��525��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowState$ 	Maximized=�6k   ��5
      �� 5   
    �� ImageSource$ /assets/skybackground.jpg��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��265* �6   �� 5      $	��57* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ groundLeftImage��5      $��assets/ground.png��6)   $
��Fill=�6D   $��1��6S   �� 5   
   -   5        $ groundCenterLeftImage��5      $��2��6/   $��assets/ground.png��6?   $
��Fill=�6Z   $��1��6i   �� 5   
   -   5        $ groundRightImage��5      $��5��6*   $��assets/ground.png��6:   $
��Fill=�6U   $��1��6d   �� 5   
   -   5        $ groundLeftCenterImage��5      $��assets/ground.png��6/   $
��Fill=�6J   $��1��6Y   $��1��6i   �� 5   
   -   5        $ groundCenterRightImage��5      $��assets/ground.png��60   $
��Fill=�6K   $��3��6Z   $��1��6j   �� 5   
   -   5        $ groundRightCenterImage��5      $��4��60   $��assets/ground.png��6@   $
��Fill=�6[   $��1��6j   �� 5    
   -   5        $ 	tank1Body��5       $��7,0,0,0q�6#   $ ��assets/tank body right.png��64   $
��Fill=�6X   $��53.29��6g   $��27��6u   $��Bottom=�6�   $
��Left=�6�   5!      �� 5"   
   -	   5        $ tank1Gun��5"      $��8��6"   $��41.75,0,0,19.25q�6-   $��assets/tank gun right.png��6F   $
��Fill=�6i   $��Bottom=�6x   $
��Left=�6�   $��36��6�    J� RenderTransformOrigin$ 0.071,0.732&�6�   z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'      T� 5(      5)      5+      �� 5,   
   -
   5        $ 	tank2Body��5,      $��5��6#   $��0,0,10,0q�63   $��assets/tank body left.png��6E   $
��Fill=�6h   $��53.29��6w   $��27��6�   $��Bottom=�6�   $��Right=�6�   �� 5-   
   -   5        $ tank2Gun��5-      $��8��6"   $��0,0,43.581,19.166q�6-   $��assets/tank gun left.png��6H   $
��Fill=�6j   $��Bottom=�6y   $��5��6�   $��Right=�6�   $��36��6�   �� 5.   
   -   5        $ tank1Missile��5.      $��68.99,0,0,18.552q�6&   $��assets/missile left.png��6@   $
��Fill=�6a   $��7.298��6p   $��Bottom=�6   $ 0.5,0.5&�6�   $
��Left=�6�   $��12.804��6�   $y�Hidden=�6�   �� 5/   
   -   5        $ tank2Missile��5/      $��5��6&   $��-5.902,0,79.598,17.844q�66   $��assets/missile right.png��6V   $
��Fill=�6x   $��7.298��6�   $��Bottom=�6�   $��12.804��6�   $��Right=�6�   $y�Hidden=�6	  51      52      