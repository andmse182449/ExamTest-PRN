   M S B A M L   `   `   `  ����D  @ExamTest2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExamTestExamTest  5   	       ExamTest.ListLessonWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ExamTest     5   	     � Title$  ListLessonWindow��5   	   $	��600��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6;    � 	Resources 5	      '   !ExamTest.BooleanToStatusConverter   BooleanToStatusConverter��%   &	          5
   
   6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��10q�6   .+�5      �� $��Quiz Exercises��6   $��24(�6.   $
��Bold"�6<   $��Center=�6N   �� 5       �� Orientation$ 
Horizontal=�6   $
��Left=�62   $��	0,10,0,10q�6M   .+�5      �� -   5         ��Name$ 
txtkeyword��5      $
��Left=�6.   $��0,0,10,0q�6I    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��195��6�   $��14(�6�   $��29��6�   �� 5      -   5         ��Name$ 	btnSearch��5      $��Search��6,   $
��Left=�6=   $	��Top=�6X   $��14(�6�   $��28��6�   $��63��6�   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ ExercisesDataGrid��5      	   AutoGenerateColumns$	 False��62   $��10q�6N   
   SelectionMode$
 Single=�6Z      
IsReadOnly$
 True��6q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Exercise Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6]   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
LessonId+6]     5      $ Exercise Name��6)   $ * 6_    6@   �� *
LessonName+6_     5      $ Date Created��6)   $ * 6^    6?   �� *
DateCreate+6^   4  .System.Windows.Controls.DataGridTemplateColumn  5       $ Status��6-   $ * 6=      CellTemplate 5!      �� 5"      .R�5#   "   �� ��6,   �� *LessonStatus+ �� 	Converter# [  5$      5&        5'      $
 Auto 6-    5(      �� 5)      .R�5*   "   �� -   5        $��View Details��5*   )   $	��100��6@   $��30��6L   6X   5+      5-      5/      �� 51      -   5        $ AddExerciseButton��51      $��Add New Exercise��60   $	��162��6K   $��41��6W   $��10q�6c   $��Right=�6o   $��15(�6�   �� 52      -   5        $ btnQuit��52      $
��Quit��6&   $��59��6K   $��29��6V   $��13(�6b   $��10q�6p   $��Right=�6|   
���  ��
�������6�   �� 54      $ 
Horizontal=�6   $
��Left=�62   $��10,0,0,0q�6M   .+�55      �� -   5        $ 
btnDisable��55      $��Disable��6-   $��40��6?   $��68��6K   $��14(�6V   $��0,0,10,0q�6d   ${�False��6v   $
��Left=�6�   $��Bottom=�6�   �� 56      -   5        $ 	btnEnable��56      $��Enable��6,   $��40��6=   $��68��6I   $��14(�6T   ${�False��6b   $
��Left=�6�   $	��Top=�6�   57      58      59      5:      