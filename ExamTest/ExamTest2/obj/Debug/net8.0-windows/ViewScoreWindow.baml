   M S B A M L   `   `   `  ����  	ExamTest2    ExamTest.ViewScoreWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  View Student Scores��5   	   $	��450��6%   $	��800��62    � WindowStartupLocation$ CenterScreen=�6>   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� $��Student Scores��6   $��24(�6.   $
��Bold"�6<   $��Center=�6N   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ScoresDataGrid��5       $��1��6      AutoGenerateColumns$ False��6W   $��10q�6s      
IsReadOnly$
 True��6   ��68   �� *Scores+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Full Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6h   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 68   �� *UsernameNavigation.FullName+6h     5      $ Lesson Name��6%   $ * 6`   	 6:   �� *Lesson.LessonName+6`     5      $ Score��6%   $ * 6O   	 64   �� *Score1+6O     5      $ Taken At��6%   $ * 6S   	 67   �� *	TakenAt+6S   5      �� 5   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5      �� -   5         ��Name$ CloseButton��5      $��Close��6*   $	��100��6:   $��30��6F   $��10q�6R   6^   5      5      5      