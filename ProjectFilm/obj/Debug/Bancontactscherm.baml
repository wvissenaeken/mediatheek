   M S B A M L   `   `   `  ����F  BProjectFilm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ProjectFilmProjectFilm  5   	   "    ProjectFilm.Bancontactscherm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ProjectFilm     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6)    � WindowStyle$
 None=�66    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowState$ 	Maximized=�6.    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�  '��       '�� Q    �� 5   
   " ��6   .�5      ��  � ��
 � ���6<   �� 5       � ��$	 350��6&   64   �� 5       � ��$	 100��6'   65   �� 5       � ��$ 32(�6)   66   �� 5       � ��$ 	ExtraBold"�6+   6?   �� 5       � ��$ Center=�69   6J   �� 5       � ��$ Center=�6;   6L   5      �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   64   �� 5       � ��$	 100��6'   65   �� 5       � ��
 � ���6<   �� 5       � ��
 �����6;   �� 5       � ��$ 32(�6)   66   �� 5       � ��$ 	ExtraBold"�6+   6?   �� 5       � ��$ Center=�69   6J   �� 5       � ��$ Center=�6;   6L   5      5      .��5      �� -   5         ��Name$ MainContainer��5      $��Center=�6(   $��Center=�6E   $��25q�6`   .+�5    
   �� 	 �� Orientation$	 Vertical=�6   .+�5!      �� -   5        
 ��Name$
 image��5!      $	��200��6#   $	��400��60   $��Resources/bancontact.jpg��6<   �� 5"      -   5        $
 image2��5"      $	��300��6$   $	��600��61   $��Resources/bc_terminal.jpg��6=   �� 5#      $	 
Horizontal=�6   $��Center=�62   .+�5$      �� -   5         ��Name$
 lbl1��5$      $��TE BETALEN BEDRAG: ��6&   �� 5%      -   5        $ 	lblBedrag��5%      $��Right=�6+   5&      �� 5'      .+�5(      �� -   5         ��Name$ 
btnBetalen��5(      $��BETAAL��6-   6>   5)      5*      5+      5,      