<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="CommentIndex.aspx.cs" Inherits="CommentIndex" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <div>
        <h2>Comments</h2>
        <asp:GridView ID="GrvComments" AutoGenerateColumns="False"
            EmptyDataText="No data available." DataKeyNames="ID" CssClass="table table-striped" runat="server">
            <columns>
                <asp:BoundField DataField="Article.Title" HeaderText="Article" 
                    ReadOnly="True" SortExpression="Article" /> 
                <asp:BoundField DataField="Name" HeaderText="Name" 
                    ReadOnly="True" SortExpression="Name" /> 
                <asp:BoundField DataField="Contents" HeaderText="Contents" 
                    ReadOnly="True" SortExpression="Contents" /> 
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkDelete" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="LnkDelete_Click" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
        <div class="form-group">
            <div class="col-md-12">
                <asp:Panel ID="PnlMessage" runat="server" Visible="False">
                    <div class="panel">
                        <asp:Label ID="LblMessage" runat="server" Text="" />
                        <asp:LinkButton ID="LnkClose" runat="server" ForeColor="#A2AAAD" OnClick="LnkClose_Click" CausesValidation="False">Close</asp:LinkButton>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
