   M S B A M L   `   `   `  ����C  ?SouthVPN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SouthVPNSouthVPN  5   	       SouthVPN.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SouthVPN     5   	     � Title$  SouthVPN��5   	    � WindowState$ 	Maximized=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   ���#f0f0f0.��5      � .+�5   
   �  � ColumnDefinitions 5      �� 5      $	��300 �6#   �� 5      $��* �6#   .+�5      � $��0��6   ���#1F2A40 � RowDefinitions 5      �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��20q�6   $	��Top=�6)   .+�5      �� $��Wähle einen Server:��6    
�������$��18(�5       $��0,0,0,10q�5        �� 5"      -   5         ��Name$ ServerListBox��5"      $	��220��5#      
�������$��0q�5%      $��14(�5&       �� SelectionMode$ Single=�5'      .@�5(      �� $��SouthVPN Server��6&    �� 
IsSelected$
 True��6@   5)      5*      �� 5,      $��20q�6   $��1��6)   $��Bottom=�66   .+�5-      �� -   5        $��Abmelden��5-      $	��220��5.      $��35��6)   ���#246795
�������$
��Bold"�51      $��0,0,0,10q�53      �� 54      -   5        $��Beenden��54      $	��220��55      $��35��6)   
������ 
�������
�������59      5:      5;      � 5>      $��1��6   .+�5@      �� $��pic/main/background.png��6   $��UniformToFill=�5A      	 J� Opacity$		 0.4Q�5B      
 K� ZIndex$
 0��5C      �� 5F      -   5        $	��200��5G      $	��200��5H      
������ 
������ $��Center=�5K      $��Center=�5L      $
 1��5M      ��5N      �� 5O       �� 
TargetType" ��6*   .R�5P      � .+�5Q   "   A�  A�Name$ ellipse��6*   
������ $��2��5S   *   
������ 5T   *   �� 5U   "   $��pic/main/OnButton.png��6(   $��Uniform=�5V   (   5W       �� Triggers 5X      P� 5Y   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5Z   &   ��  �� 
TargetName$ ellipse��6-    �� Property � �� �� Value �#2467956T   5[   #   5]      5_      �� 5a      $��Center=�6   $	��Top=�5b      $��0,80,0,0q�5c      $
 2��5d      .+�5e      �� $��Willkommen bei SouthVPN��6    $��28(�5f       $
��Bold"�5g       ���#246795$��0,0,0,10q�5i        �� TextAlignment$ Center=�5j       5k      5l      5m      5n      5o      