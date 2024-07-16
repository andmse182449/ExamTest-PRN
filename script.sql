
USE [ExamTest]
GO
/****** Object:  Table [dbo].[account]    Script Date: 7/13/2024 3:00:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[username] [varchar](20) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[fullName] [nvarchar](100) NOT NULL,
	[role] [int] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lessons]    Script Date: 7/13/2024 3:00:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lessons](
	[lessonID] [varchar](20) NOT NULL,
	[lessonName] [varchar](100) NOT NULL,
	[LessonStatus] [bit] NULL,
	[DateCreate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[lessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 7/13/2024 3:00:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[questionID] [int] IDENTITY(1,1) NOT NULL,
	[lessonID] [varchar](20) NOT NULL,
	[questionText] [text] NOT NULL,
	[optionA] [varchar](100) NOT NULL,
	[optionB] [varchar](100) NOT NULL,
	[optionC] [varchar](100) NOT NULL,
	[optionD] [varchar](100) NOT NULL,
	[correctAnswer] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[questionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[score]    Script Date: 7/13/2024 3:00:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[score](
	[username] [varchar](20) NOT NULL,
	[lessonID] [varchar](20) NOT NULL,
	[score] [int] NOT NULL,
	[takenAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[lessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[account] ([username], [password], [fullName], [role], [status]) VALUES (N'ad', N'1', N'Nguyễn Quốc Bảo', 2, 0)
INSERT [dbo].[account] ([username], [password], [fullName], [role], [status]) VALUES (N's1', N'1', N'Nguyễn Quốc An', 1, 0)
INSERT [dbo].[account] ([username], [password], [fullName], [role], [status]) VALUES (N's2', N'1', N'Nguyễn Quốc Phúc', 0, 0)


GO
INSERT [dbo].[lessons] ([lessonID], [lessonName], [LessonStatus], [DateCreate]) VALUES (N'swp391', N'swp', 1, CAST(N'2024-06-28' AS Date))
GO
SET IDENTITY_INSERT [dbo].[questions] ON 

INSERT [dbo].[questions] ([questionID], [lessonID], [questionText], [optionA], [optionB], [optionC], [optionD], [correctAnswer]) VALUES (4, N'swp391', N'1 + 1', N'2', N'3', N'4', N'5', N'A')
SET IDENTITY_INSERT [dbo].[questions] OFF
GO
ALTER TABLE [dbo].[score] ADD  DEFAULT (getdate()) FOR [takenAt]
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD FOREIGN KEY([lessonID])
REFERENCES [dbo].[lessons] ([lessonID])
GO
ALTER TABLE [dbo].[score]  WITH CHECK ADD FOREIGN KEY([lessonID])
REFERENCES [dbo].[lessons] ([lessonID])
GO
ALTER TABLE [dbo].[score]  WITH CHECK ADD FOREIGN KEY([username])
REFERENCES [dbo].[account] ([username])
GO
ALTER TABLE [dbo].[questions]  WITH CHECK ADD CHECK  (([correctAnswer]='D' OR [correctAnswer]='C' OR [correctAnswer]='B' OR [correctAnswer]='A'))
GO
select * from account
select * from lessons
select * from questions
select * from score

        <Label Content="User Name" HorizontalAlignment="Left" Margin="51,61,0,0" VerticalAlignment="Top" RenderTransformOrigin="0.271,1.619"/>
        <TextBox x:Name="user" HorizontalAlignment="Left" Margin="126,63,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="244" Height="22" />