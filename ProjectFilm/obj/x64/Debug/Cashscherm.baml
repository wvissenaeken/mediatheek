   M S B A M L   `   `   `  ����F  BProjectFilm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectFilmProjectFilm  5   	       ProjectFilm.Cashscherm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjectFilm     5   	     � Title$  
MainWindow��5   	   $	��864��6   $
��1024��6,    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�6.   .��5      �� -   5         ��Name$ GroupBoxInworp��5      {�. $��Inworp��68   $��Center=�6H   $��10,120,10,0q�6e   $	��Top=�6z   $��Stretch=�6�   .��5   
   �� -   5         ��Name$ StackPanelInworp��5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��0q�6g   .+�5      �� -   5         ��Name$ 
btn100Euro��5      $��10q�6-   $	��250��69   $	��100��6H   $	��140��6�   ��6l   Z� ��6�   Z� ��5      �� 5      	 �� ImageSource$?	 9pack://siteoforigin:,,,/Resources/100EuroSchein-800px.png��6%   
 j� Stretch$
 Uniform=�6n   5      �� 5      -   5        $ 	btn50Euro��5      $��10q�6,   $	��250��68   $��50��6G   ��6j   Z� ��5      �� 5      $>	 8pack://siteoforigin:,,,/Resources/50EuroSchein-800px.png��6%   $
 Uniform=�6l   5      �� 5      -   5        $ 	btn20Euro��5      $��10q�6,   $	��250��68   $��20��6G   ��6j   Z� ��5      �� 5      $>	 8pack://siteoforigin:,,,/Resources/20EuroSchein-800px.png��6%   $
 Uniform=�6l   5      5      �� 5      $ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��0q�6g   .+�5      �� -   5        $ 	btn10Euro��5      $��10q�6,   $	��250��68   $��10��6G   $	��140��6�   ��6j   Z� ��5       �� 5!      $>	 8pack://siteoforigin:,,,/Resources/10EuroSchein-800px.png��6%   $
 Uniform=�6l   5#      �� 5$      -   5        $ btn5Euro��5$      $��10q�6+   $	��250��67   $��5��6F   ��6h   Z� ��5%      �� 5&      $=	 7pack://siteoforigin:,,,/Resources/5euroSchein-800px.png��6%   $
 Uniform=�6k   5(      5)      �� 5*      $ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��0q�6g   .+�5+      �� -   5        $ btn2Euro��5+      $��10q�6+   $	��100��67   $��2��6F   $	��100��6�   ��6h   Z� ��5,      �� 5-      $7	 1pack://siteoforigin:,,,/Resources/2euro-800px.png��6%   $
 Uniform=�6e   5/      �� 50      -	   5        $ btn1Euro��50      $��10q�6+   $	��100��67   $��1��6F   ��6h   Z� ��51      �� 52      $7	 1pack://siteoforigin:,,,/Resources/1euro-800px.png��6%   $
 Uniform=�6e   54      �� 55      -
   5        $ btn50Eurocent��55      $��10q�60   $	��100��6<   $
��0,50��6K   ��6p   Z� ��56      �� 57      $8	 2pack://siteoforigin:,,,/Resources/50cent-800px.png��6%   $
 Uniform=�6f   59      �� 5:      -   5        $ btn20Eurocent��5:      $��10q�60   $	��100��6<   $
��0,20��6K   $��60��6�   ��6p   Z� ��5;      �� 5<      $8	 2pack://siteoforigin:,,,/Resources/20cent-800px.png��6%   $
 Uniform=�6f   5>      �� 5?      -   5        $ btn10Eurocent��5?      $��10q�60   $	��100��6<   $
��0,10��6K   ��6p   Z� ��5@      �� 5A      $
 Uniform=�6%   $8	 2pack://siteoforigin:,,,/Resources/10cent-800px.png��67   5C      �� 5D      -   5        $ btn5Eurocent��5D      $��10q�6/   $	��100��6;   $
��0,05��6J   ��6o   Z� ��5E      �� 5F      $=	 7pack://siteoforigin:,,,/Resources/5-euro-cent-800px.png��6%   $
 Uniform=�6k   5H      5I      �� 5J      $ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   $��5q�6g   .+�5K      �� $��Huidige inworp:��6   $	��160��62   6C   �� 5L      -   5         ��Name$ lblHuidigeInworp��5L      $�� ��62   $	��300��6=   $��Right=�6L   6q   5M      5N      5O      5P      