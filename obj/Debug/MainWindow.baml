   M S B A M L   `   `   `  ����>  :RAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RAPRAP  5   	       RAP.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RAP     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5	      � $
��Left=�6    � ColumnDefinitions 5
   
   �� 5      $
��294* �6   �� 5      $
��319* �6   �� 5      $
��380* �6   $��RightToLeft=�6,   �� 5      $��0* �6   .+�5   
   � $��317.4,10,-1.2,0.4q�6   $��1��6*   $��3��6:   .+�5      (�  (� Stretch$ UniformToFill=�6   $��0,0,-183,10q�6.   .��5      �� $��0q�6   $��Right=�6(   $	��Top=�6D   $	��620��6\   .+�5      �� $��Publication Detail��6   $��167,50,260.8,0q�69   $��16(�6Q   $��31��6_   $��Right=�6k   �� 5      -   5         ��Name$ pubDetailPanel��5   !   $��
50,0,0,200q�69   $
��Left=�6M   $	��444��6h   $	��369��6u   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��51��6>   $��Right=�6J   $��
0,0,-0.2,0q�6f   .+�5      �� $
��DOI:��6$   $��45��63   �� 5      $
��Wrap=�6(   $��0,4,0,0q�6R   $	��215��6c   $	��Top=�6o   $��25��6�   ��6=   �� *DOI+6�   5      �� 5      $ 
Horizontal=�6%   $��79��6>   $��Right=�6J   $��
0,0,-0.2,0q�6f   .+�5      �� $��Title: ��6$   $��49��66   �� 5      $
��Wrap=�6(   $	��206��6S   $��0,5,8,0q�6_   $	��Top=�6p   ��6<   �� *Title+6p   5      �� 5       $ 
Horizontal=�6%   $��60��6>   $��Right=�6J   .+�5!      �� $��Authors:��6$   $��60��67   �� 5"      $
��Wrap=�6(   $	��201��6U   $	��Top=�6a   $��0,2,0,0q�6y   ��6<   �� *	Authors+6y   5#      �� 5%      $ 
Horizontal=�6%   $��Right=�6>   .+�5&      �� $��Year:��6$   �� 5'      $��60��6=   ��6$   �� *Year+6=   �� 5(      $��Available Since:��6$   �� 5)      $��75��6B   ��6$   �� *	Available+6B   5*      �� 5-      $ 
Horizontal=�6%   $��Center=�6>   .+�5.      �� $��Type:��6$   $��42��64   $
��Left=�6?   �� 5/      ��6$   �� *Type+50      �� 53      $ 
Horizontal=�6%   $	��149��6>   $��Right=�6K   .+�54      �� $��Cite As:��6$   $��61��67   �� 55      $	��200��6(   $
��Wrap=�6M   $��0,6,0,0q�6a   $	��Top=�6r   ��64   �� *	Cite_as+6r   56      58      59      5:      5;      � 5>   
   $��0,0,32.6,0.4q�6    � RowDefinitions 5?      �� 5@      $	��55* �6    �� 5A      $	��52* �6    �� 5B      $
��343* �6    .+�5F      �� $��Search by name: ��6   $
��Left=�6/   $	��Top=�6J   $��	10,20,0,0q�6b   $��30��6u   $	��100��6�   �� 5H      $��Group by��6   $
��Left=�6'   $	��Top=�6B   $��10,14.4,0,0q�6Z   $��1��6o   $��30��6|   $��65��6�   �� 5I      -   5         ��Name$ SelectLevel��5I      $
��Left=�6,   $	��Top=�6G   $	��150��6_   $��30��6k   $��110,14.667,0,0q�6w   $��1��6�    �� SelectedIndex$ 0��5K      ��5J      ��    levelValues �� Source# [  5K   %   �� 5L      -   5        	 ��Name$	 
filterName��5L      $
��Left=�6*   $��30��6E   
 �� TextWrapping$

 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $	��150��6�   $��
110,20,0,0q�6�   6�   �� 5M      -   5         ��Name$ ResearchersList��5M      $��10,9.8,39.8,214.4q�6/   $��2��6J   ��6|   ��   researcherList# [ 5O      � 5R   
   $��2��6   $��0.4,0,338.8,0.4q�6#   $��1��6<   .+�5S      (� $ Uniform=�6   $��
0,10,50,10q�6(   .��5T      �� -   5        $ researcherDetailPanel��5T      $��0,10,0,0q�6<   .+�5V      �� $��199,0,4.8,0q�6!   $	��149��66   .+�5W      �� -   5         ��Name$ Staff_photo��5W       $��Uniform=�6N   $	��120��6a   $	��124��6q   $��0q�6~    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��Right=�6�   ��65   �� *Photo+6�   5X      �� 5Z      $ 
Horizontal=�6!   $��0,-140,-0.2,0q�6:   .+�5[      �� $��Name:��6    �� 5\      ��6    �� *Title+�� 5]      ��6    �� *	GivenName+�� 5^      $	��152��6?   ��6    �� *
FamilyName+6?   5_      �� 5`      $ 
Horizontal=�6!   $��
0,-120,0,0q�6:   .+�5a      �� $��Unit:��6    �� 5b      $
��auto��69   ��6    �� *Unit+69   5c      �� 5d      $ 
Horizontal=�6!   $��
0,-100,0,0q�6:   .+�5e      �� $��Campus:��6    �� 5f      ��6    �� *Campus+5g      �� 5i      $ 
Horizontal=�6!   $��0,-80,-0.2,0q�6:   .+�5j      �� $��Email:��6    �� 5k      ��6    �� *Email+5l      �� 5n      $ 
Horizontal=�6!   $��	0,-60,0,0q�6:   .+�5o      �� $��Current Job:��6    �� 5p      ��6    �� *
CurrentJob+5q      �� 5s      $ 
Horizontal=�6!   $��0q�6:   .+�5t      �� $!��Commenced with institution:��6    �� 5u      ��6    �� *EarliestStart+5v      �� 5x      $ 
Horizontal=�6!   $��0q�6:   .+�5y      �� $!��Commenced current position:��6    �� 5z      ��6    �� *CurrentJobStartDate+5{      �� 5}      $ 
Horizontal=�6!   $��	0,0,9.8,0q�6:   .+�5~      �� $��Previous position:��6    $��0q�6=   $
��Left=�6H   �� 5      -   5        $ positionList��5   #   $
��Left=�6Z   $	��220��6u   $ 0��6�   $��
0,0,0,-0.2q�6�   ��69   �� *
Position+6�   5�      �� 5�      $ 
Horizontal=�6!   $��0,0,-0,0q�6:   .+�5�      �� $��Tenure (days):��6    �� 5�      ��6    �� *Tenure+5�      �� 5�      $ 
Horizontal=�6!   $��0,0,-0,0q�6:   .+�5�      �� $��Publication:��6    �� 5�      ��6    �� *PublicationCount+�� 5�      $��Cumulative Count��6!   $
��Auto��6<   5�      �� 5�      $ 
Horizontal=�6!   $��0,0,-0,0q�6:   .+�5�      �� $��3-year average:��6    �� 5�      ��6    �� *ThreeYearAverage+5�      �� 5�      $ 
Horizontal=�6!   $��0,0,-0,0q�6:   .+�5�      �� $��Performance:��6    �� 5�      ��6    �� *Performance+5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Supervisions:��6    �� 5�      $	��150��6"   $ 0��6R   ��6.   �� *Supervision+6R   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Degree:��6    $��54��62   �� 5�      ��6    �� *Degree+�� 5�      $��Supervisior:��6    �� 5�      $��51��6?   ��6    �� *
Supervisor+6?   5�      �� 5�      $ 
Horizontal=�6!   .+�5�      �� $��Publication:��6    $��80��67   �� 5�      -   5        $	��251��5�   "   $	��100��6.   ��6f   �� *Publication+5�      5�      5�      5�      5�      5�      