   M S B A M L   `   `   `  ����E  APlat_Tanks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Plat_Tanks
Plat_Tanks  5   	       Plat_Tanks.StartWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Plat_Tanks     5   	     � Title$  Tanks��5   	   $	��350��6   $	��525��6$    � 
ResizeMode$ NoResize=�60    � WindowStartupLocation$ CenterScreen=�6F    � WindowState$ 	Maximized=�6k   ��5	      �� 5
   
    �� ImageSource$ /assets/skybackground.jpg��6   .��5      � .+�5   
   � -   5        $��HomeGrid��5      $y�Visible=�6    � RowDefinitions 5      �� 5      $	��88* �6    �� 5      $	��71* �6    �� 5      $	��64* �6    �� 5      $	��99* �6    .+�5      �� -   5         ��Name$ title��5      $#��186.311,17.961,183.947,-6.897q�6'   $
��Wrap=�6N   $��Tanks��6b   $��Tekton Pro Ext)�6o   $��64(�6�    �� TextAlignment$ Center=�6�   �� 5      -   5         ��Name$ hotSeatButton��5      $��Hot Seat��6,   $��Tekton Pro Cond)�6?   $��40(�6\   $��150,2,139,12q�6�   $��2��6�   ��5      �� 5      5      �� 5      -   5        $ instructionsButton��5      $��Instructions
��61   $��150,8,139,10q�6R   $��Tekton Pro Cond)�6h   $��40(�6�   $��1��6�   ��5      �� 5      5      �� 5      -   5        $ internetButton��5      $��Internet��6-   $��175,39,197,10q�6@   $��Tekton Pro Cond)�6W   $��40(�6t   $��3��6�   $y�Hidden=�6�   ��5       �� 5!      5#      �� 5$      -   5        $ highScoresButton��5$      $��High Scores��6/   $��150,5,139,60q�6E   $��3��6[   $��Tekton Pro Cond)�6h   $��40(�6�   ��6�   Z� 6�   5%      � 5&   
   -   5        $��internetConnectGrid��5&      $y�Hidden=�6*   .+�5'      �� -   5        $ 
hostButton��5'      $
��Host��6)   $��203,48,172,0q�68   $��42��6g   $	��Top=�6s   �� 5(      -	   5        $ connectButton��5(      $��Connect��6,   $��203,146,172,0q�6>   $��44��6q   $	��Top=�6}   �� 5)      -
   5        	 ��Name$	 ipAddressTextBox��5)      $��42��60   $��78,0,143,45q�6<   
 �� TextWrapping$

 Wrap=�6Q   $��
10.70.1.49��6e   $��Bottom=�6w   $��29.333(�6�   $��Tahoma)�6�   �� 5*      -   5        $ connectToIP��5*      $��Connect to this IP��6*   $��Right=�6G   $��	0,0,31,45q�6c   $��Bottom=�6v   $	��102��6�   $��43��6�   6�   5+      � 5,   
   -   5        $��highScoresGrid��5,      $y�Hidden=�6%    5-      �� 5.      $��1* �6    �� 5/      $��1* �6    �� 50      $��1* �6    �� 51      $��2* �6    .+�53      �� -   5        $ highScoresBackButton��53      $
��Back��63   $��131,32,125,10q�6B   $��
Tekton Pro)�6o   $��53.333(�6�   $��3��6�   ��6Y   Z� 6�   �� 54      -   5        $ highestScoreText��54      $��104,12,80,11q�62   $
��Wrap=�6H   $��0 Shots��6\   $��
Tekton Pro)�6k   $��40(�6�   $ Center=�6�   �� 55      -   5        $ secondHighestScoreText��55      $��104,10,80,13q�68   $
��Wrap=�6N   $��0 Shots��6b   $��
Tekton Pro)�6q   $��40(�6�   $��1��6�   $ Center=�6�   �� 56      -   5        $ thirdHighestScoreText��56      $��104,14,80,10q�67   $
��Wrap=�6M   $��0 Shots��6a   $��
Tekton Pro)�6p   $��40(�6�   $��2��6�   $ Center=�6�   58      � 59   
   -   5        $��instructionsGrid��59      $y�Hidden=�6'   .+�5:      �� -   5        $ instructionsBackButton��5:      $
��Back��65   $��
55,0,29,16q�6D   $��Tekton Pro Cond)�6n   $��53.333(�6�   $��97��6�   $��Bottom=�6�   ��6X   Z� 6�   �� 5;      -   5        $ instructionsText��5;      $��55,0,29,118q�62   $
��Wrap=�6G   $
��text��6[   $��Bottom=�6g   $	��179��6�   $��
Tekton Pro)�6�   $��26.667(�6�   5=      5>      5?      