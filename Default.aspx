<%@ Reference Control="~/controls/listeservicescontrol.ascx" %>
<%@ Reference Control="~/controls/listeprocesscontrol.ascx" %>
<%@ Reference Control="~/controls/listeprogramscontrol.ascx" %>
<%@ Reference Control="~/controls/disquescontrol.ascx" %>
<%@ Reference Control="~/controls/programscontrol.ascx" %>
<%@ Reference Control="~/controls/servicescontrol.ascx" %>
<%@ Reference Control="~/controls/memoirecontrol.ascx" %>
<%@ Reference Control="~/controls/hardwarecontrol.ascx" %>
<%@ Reference Control="~/controls/serverlogincontrol.ascx" %>
<%@ Reference Control="~/controls/frameworkcontrol.ascx" %>
<%@ Reference Control="~/controls/networktrafficcontrol.ascx" %>
<%@ Reference Control="~/controls/networkcontrol.ascx" %>
<%@ Reference Control="~/controls/systemcontrol.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA._Default" CodeFile="Default.aspx.vb" %>
<%@ Register TagPrefix="uc1" TagName="ServerLoginControl" Src="Controls/ServerLoginControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ProgramsControl" Src="Controls/ProgramsControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SignatureControl" Src="Controls/SignatureControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NetworkControl" Src="Controls/NetworkControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DisquesControl" Src="Controls/DisquesControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="FrameworkControl" Src="Controls/FrameworkControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SystemControl" Src="Controls/SystemControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemoireControl" Src="Controls/MemoireControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HardwareControl" Src="Controls/HardwareControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ServicesControl" Src="Controls/ServicesControl.ascx" %>
<%@ Register TagPrefix="uc1" TagName="NetworkTrafficControl" Src="Controls/NetworkTrafficControl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//FR">
<HTML>
	<HEAD>
		<title>DotNet System Information</title>
		<meta content="Microsoft Visual Studio&nbsp;.NET&nbsp;7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie3-2nav3-0" name="vs_targetSchema">
		<meta http-equiv="Site-Enter" content="revealTrans(Duration=1.0,Transition=23)">
		<meta http-equiv="Site-Exit" content="revealTrans(Duration=1.0,Transition=23)">
		<meta http-equiv="Page-Exit" content="revealTrans(Duration=1.0,Transition=23)">
		<meta http-equiv="Page-Enter" content="revealTrans(Duration=1.0,Transition=23)">
		<META HTTP-EQUIV="Page-Enter" Content="blendtrans(duration=1.0)">
	</HEAD>
	<body marginwidth="0" marginheight="0" topmargin="2" leftmargin="2" rightmargin="0" onload="window.defaultStatus='DotNetSysInfo';return true;">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<asp:Panel id="BasePanel" runat="server" Visible="false" Width="100%">
					<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
						<TR>
							<TD vAlign="top" align="center">
								<uc1:systemcontrol id="SystemControl1" runat="server"></uc1:systemcontrol><BR>
								<uc1:networkcontrol id="NetworkControl1" runat="server"></uc1:networkcontrol><BR>
								<uc1:NetworkTrafficControl id="NetworkTrafficControl1" runat="server"></uc1:NetworkTrafficControl><BR>
								<asp:Panel id="PanelFrameWork" runat="server" Width="100%" Visible="false">
									<uc1:FrameworkControl id="FrameworkControl1" runat="server"></uc1:FrameworkControl>
								</asp:Panel></TD>
							<TD vAlign="top">
								<uc1:ServerLoginControl id="ServerLoginControl1" runat="server"></uc1:ServerLoginControl><BR>
								<uc1:hardwarecontrol id="HardwareControl1" runat="server"></uc1:hardwarecontrol><BR>
								<uc1:memoirecontrol id="MemoireControl1" runat="server"></uc1:memoirecontrol><BR>
								<uc1:servicescontrol id="ServicesControl1" runat="server"></uc1:servicescontrol><BR>
								<uc1:ProgramsControl id="ProgramsControl1" runat="server"></uc1:ProgramsControl></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2"></TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<uc1:disquescontrol id="DisquesControl1" runat="server"></uc1:disquescontrol><BR>
							</TD>
						</TR>
					</TABLE>
				</asp:Panel>
				<asp:Panel id="DetailPanel" runat="server" Visible="false" Width="100%"></asp:Panel>
				<br>
				<uc1:SignatureControl id="SignatureControl1" runat="server"></uc1:SignatureControl>
			</CENTER>
		</form>
	</body>
</HTML>
