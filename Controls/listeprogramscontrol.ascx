<%@ Control Language="vb" AutoEventWireup="false" Inherits="DotNetSysInfoJA.ListeProgramsControl" CodeFile="ListeProgramsControl.ascx.vb" %>
<TABLE class="boxheader" cellSpacing="0" cellPadding="0" width="99%" border="1">
	<TR>
		<TD>
			<TABLE class="boxheader" cellSpacing="0" cellPadding="4" width="100%" border="0">
				<TR vAlign="top">
					<TD class="boxheader" align="center">Liste des Logiciels</TD>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR>
					<TD class="SecondNiveau">Liste des Logiciels install�s sur la machine</TD>
				</TR>
				<TR>
					<TD class="boxbody">
						<asp:DataGrid id="DataGridListePrograms" runat="server" EnableViewState="False" Width="100%" CellPadding="1"
							BorderWidth="0px" CssClass="boxbody">
							<AlternatingItemStyle CssClass="boxbodyalternate"></AlternatingItemStyle>
							<SelectedItemStyle CssClass="boxbody"></SelectedItemStyle>
							<ItemStyle CssClass="boxbody"></ItemStyle>
							<HeaderStyle Font-Bold="True" CssClass="auteur"></HeaderStyle>
						</asp:DataGrid>
						<asp:Label id="LabelAlert" runat="server" EnableViewState="False" ForeColor="DarkRed" Font-Italic="True"
							Font-Bold="True" Visible="False"></asp:Label>
					</TD>
				</TR>
				<TR height="1">
					<TD height="1" class="interligne"></TD>
				</TR>
				<TR vAlign="top">
					<TD class="boxheader" align="left">&nbsp;</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</TABLE>
