   M S B A M L   `   `   `  ����E  APlat_Tanks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Plat_Tanks
Plat_Tanks  5   	       Plat_Tanks.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Plat_Tanks     5   	   c _Microsoft.Expression.Drawing, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  5   	   -   5          � Title$  Tanks��5	   	   $	��350��6   $	��525��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowState$ 	Maximized=�6k    � 	Resources 5
         victoryStoryboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Visible	 R� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value��%   &	        �� 5   
   .��5      T� $ (UIElement.Visibility)�6,   $ 
endMissile��6_   ..�5      i� $ 0��6)   #	 Z 65   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $ 
endMissile��6�   .\�5        $
 0��6'   $ 0Q�63     5      $
 0:0:0.7��6'   $ -1Q�69   5      U� 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $ 
endMissile��6�   .\�5        $
 0��6'   $ 0Q�63     5      $
 0:0:0.7��6'   $	 170Q�69   5      T� 5      $ (UIElement.Visibility)�6,   $
 boom��6_   ..�5      i� $ 0:0:0.7��6)   #	 Z 6;   i� 5      $ 0:0:1.3��6)   #	 Z 6;   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6,   $
 boom��6�   .\�5      n� $
 0:0:0.7��6)   $ 0.225Q�6;     5      $
 0:0:1.3��6'   $ 0.995Q�69   5      U� 5      $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6,   $
 boom��6�   .\�5       n� $
 0:0:0.7��6)   $ 0.329Q�6;     5!      $
 0:0:1.3��6'   $ 1Q�69   5"      U� 5#      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6,   $
 boom��6�   .\�5$      n� $
 0:0:0.7��6)   $ -1Q�6;     5%      $
 0:0:1.3��6'   $ -1Q�69   5&      U� 5'      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�6,   $
 boom��6�   .\�5(      n� $
 0:0:0.7��6)   $ 78Q�6;     5)      $
 0:0:1.3��6'   $ 0Q�69   5*      T� 5+      $ (UIElement.Visibility)�6,   $ screenRectangle��6_   ..�5,      i� $ 0:0:1.4��6)   #	 Z 6;   i� 5-      $ 0:0:1.6��6)   #	 Z 6;   5.      U� 5/      $ (UIElement.Opacity)�6,   $ screenRectangle��6\   .\�50        $
 0:0:1.4��6'   $ 0Q�69     51      $
 0:0:1.6��6'   $	 0.8Q�69   52      53      54       � Triggers 55      :� 56   
    :� RoutedEvent$ FrameworkElement.Loaded��6   57      ��59      �� 5:   
    �� ImageSource$ /assets/skybackground.jpg��6   .��5<      �  � RowDefinitions 5=   
   �� 5>      $
��265* �6   �� 5?      $	��57* �6    � ColumnDefinitions 5A   
   �� 5B      $��* �6   �� 5C      $��* �6   �� 5D      $��* �6   �� 5E      $��* �6   �� 5F      $��* �6   �� 5G      $��* �6   .+�5I   
   �� -   5         ��Name$ groundLeftImage��5I      $��assets/ground.png��6)   $
��Fill=�6D   $��1��6S   �� 5J   
   -   5        $ groundCenterLeftImage��5J      $��2��6/   $��assets/ground.png��6?   $
��Fill=�6Z   $��1��6i   �� 5K   
   -   5        $ groundRightImage��5K      $��5��6*   $��assets/ground.png��6:   $
��Fill=�6U   $��1��6d   �� 5L   
   -   5        $ groundLeftCenterImage��5L      $��assets/ground.png��6/   $
��Fill=�6J   $��1��6Y   $��1��6i   �� 5M   
   -   5        $ groundCenterRightImage��5M      $��assets/ground.png��60   $
��Fill=�6K   $��3��6Z   $��1��6j   �� 5N   
   -   5        $ groundRightCenterImage��5N      $��4��60   $��assets/ground.png��6@   $
��Fill=�6[   $��1��6j   �� 5O   
   -   5        $ 	tank1Body��5O      $��7,0,0,0q�6#   $ ��assets/tank body right.png��64   $
��Fill=�6X   $��53.29��6g   $��27��6u   $��Bottom=�6�   $
��Left=�6�   �� 5P   
   -	   5        $ tank1Gun��5P      $��8��6"   $��41.75,0,0,19.25q�6-   $��assets/tank gun right.png��6F   $
��Fill=�6i   $��Bottom=�6x   $
��Left=�6�   $��36��6�    J� RenderTransformOrigin$ 0.071,0.732&�6�   z�5Q      V� 5R      .~�5S      �� �� 5T      �� 5U      T� 5V      5W      5Y      �� 5Z   
   -
   5        $ 	tank2Body��5Z      $��5��6#   $��0,0,10,0q�63   $��assets/tank body left.png��6E   $
��Fill=�6h   $��53.29��6w   $��27��6�   $��Bottom=�6�   $��Right=�6�   �� 5[   
   -   5        $ tank2Gun��5[      $��8��6"   $��0,0,43.581,19.166q�6-   $��assets/tank gun left.png��6H   $
��Fill=�6j   $��Bottom=�6y   $��5��6�   $��Right=�6�   $��36��6�   �� 5\   
   -   5        $ tank1Missile��5\      $��68.99,0,0,18.552q�6&   $��missile left.png��6@   $
��Fill=�6Z   $��7.298��6i   $��Bottom=�6x   $ 0.5,0.5&�6�   $
��Left=�6�   $��12.804��6�   $y�Hidden=�6�   �� 5]   
   -   5        $ tank2Missile��5]      $��5��6&   $��0,0,73.045,17.844q�66   $��assets/missile right.png��6Q   $
��Fill=�6s   $��7.298��6�   $��Bottom=�6�   $��12.804��6�   $��Right=�6�   $y�Hidden=�6�   �� 5^   
   -   5        $ 
endMissile��5^      $��3��6$   $��-34.5,10,0,0q�64   $��assets/missileDown.png��6J   $
��Fill=�6j   $	��101��6y   $	��Top=�6�   $
��Left=�6�   $��70��6�   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5_      V� 5`      .~�5a      �� �� 5b      �� 5c      T� 5d      5e      5g      �� 5h   
   -   5        $
 boom��5h      $��6��6   $��0,0,0,0q�62   $��assets/bigExplosion.png��6C   $
��Fill=�6d   $��2��6s   $y�Hidden=�6�   $ 0.5,0.5&�6�   z�5i      V� 5j      .~�5k      �� �� 5l      �� 5m      T� 5n      5o      5q      �� 5r   
   -   5         ��Name$ screenRectangle��5r      
���   �$!��-0.815,-1.699,-1.787,-0.573q�6:   
���   �$��6��6n   $��2��6�    J� Opacity$	 0.8Q�6�   $y�Hidden=�6�   �� 5s   
   -   5         ��Name$ winnerTextBlock��5s      $ ��29.037,86.96,42.503,117.08q�6-   $
��Wrap=�6Q   $��6��6e   $��Tekton Pro Ext)�6y   $��64(�6�   
������� �� TextAlignment$ Center=�6�   $y�Hidden=�6�   �� 6�   $�Player 1 Wins!��6�   6�   �� 5t   
   -   5        $ Display��5t      $��40.63,50.746,21.451,0q�6%   $
��Wrap=�6D   $��Player 1 Turn��6X   $	��Top=�6m   $��Tekton Pro Ext)�6�   $��64(�6�   $��6��6�   $ Center=�6�   $y�Hidden=�6�   
�������6�   �� 5u   
   -   5        $ 
subDisplay��5u      $��27,176,34,61q�6(   $
��Wrap=�6>   $��Press Any Key To Start��6R   $ Center=�6p   $��Tekton Pro Ext)�6�   $��24(�6�   $��6��6�   
�������$y�Hidden=�6�   �� 5v   
   -   5        $ timeDisplay��5v      $��4��6)   $��-11.331,28.116,18.895,0q�69   $
��Wrap=�6Z   $��30.00 Seconds��6n   $	��Top=�6�   $��Tekton Pro Ext)�6�   $��24(�6�   $��2��6�   $��Right=�6�   $��165.436��6�   $ Right=�6  5w      5x      