<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True"
    CodeBehind="CategoryIndex.aspx.cs" Inherits="CategoryIndex" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <div>
        <h2>Categories</h2>
        <p>
            <a href="CreateCategory.aspx">Create New</a>
        </p>
        <asp:GridView ID="GrvCategories" AutoGenerateColumns="False"
            EmptyDataText="No data available." DataKeyNames="ID" CssClass="table table-striped" runat="server">
            <columns>
                <asp:BoundField DataField="Name" HeaderText="Name" 
                    ReadOnly="True" SortExpression="Name" /> 
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkEdit" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="LnkEdit_Click" Text="Edit"></asp:LinkButton> | 
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
