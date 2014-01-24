USE [SEM]
GO

/****** Object:  Table [dbo].[t_alive]    Script Date: 01/25/2014 00:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_alive](
	[local_id] [bigint] IDENTITY(1,1) NOT NULL,
	[ip_address] [varchar](50) NULL,
	[mac_address] [varchar](50) NULL,
	[create_time] [datetime] NULL,
 CONSTRAINT [PK_t_alive] PRIMARY KEY CLUSTERED 
(
	[local_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [SEM]
GO

/****** Object:  Table [dbo].[t_item_click]    Script Date: 01/25/2014 00:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_item_click](
	[local_id] [bigint] IDENTITY(1,1) NOT NULL,
	[item_id] [bigint] NULL,
	[mac_address] [varchar](50) NULL,
	[ip_address] [varchar](50) NULL,
	[local_item_task_id] [uniqueidentifier] NOT NULL,
	[is_succeed] [bit] NULL,
	[create_time] [datetime] NOT NULL,
	[update_time] [datetime] NOT NULL,
 CONSTRAINT [PK_t_item_click] PRIMARY KEY CLUSTERED 
(
	[local_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N't_my_item表外键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N't_item_click', @level2type=N'COLUMN',@level2name=N'local_item_task_id'
GO

USE [SEM]
GO

/****** Object:  Table [dbo].[t_item_task]    Script Date: 01/25/2014 00:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_item_task](
	[local_item_task_id] [uniqueidentifier] NOT NULL,
	[item_id] [bigint] NOT NULL,
	[nick] [varchar](100) NULL,
	[item_title] [varchar](100) NULL,
	[img_url] [varchar](100) NULL,
	[price] [decimal](10, 2) NULL,
	[max_click] [int] NULL,
	[run_days] [int] NULL,
	[creative_one_title] [varchar](100) NULL,
	[creative_two_title] [varchar](100) NULL,
	[keyword] [varchar](100) NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
	[remark] [varchar](1000) NULL,
	[is_enable] [bit] NULL,
	[is_succeed] [bit] NULL,
 CONSTRAINT [PK_t_my_item] PRIMARY KEY CLUSTERED 
(
	[local_item_task_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [SEM]
GO

/****** Object:  Table [dbo].[t_msg]    Script Date: 01/25/2014 00:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_msg](
	[local_msg_id] [bigint] IDENTITY(1,1) NOT NULL,
	[msg_from] [varchar](50) NULL,
	[msg_to] [varchar](50) NULL,
	[msg_subject] [nvarchar](50) NULL,
	[msg_content] [nvarchar](4000) NULL,
	[msg_type] [nvarchar](10) NULL,
	[file_path] [varchar](100) NULL,
	[send_status] [tinyint] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_t_msg] PRIMARY KEY CLUSTERED 
(
	[local_msg_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [SEM]
GO

/****** Object:  Table [dbo].[t_user]    Script Date: 01/25/2014 00:27:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[t_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](50) NULL,
	[pwd] [nvarchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](50) NULL,
	[mac_address] [varchar](50) NULL,
	[ip_address] [varchar](50) NULL,
	[cpu] [varchar](50) NULL,
	[mem] [varchar](50) NULL,
	[os] [varchar](50) NULL,
	[user_level] [tinyint] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_t_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[t_alive] ADD  CONSTRAINT [DF_t_alive_create_time]  DEFAULT (getdate()) FOR [create_time]
GO

