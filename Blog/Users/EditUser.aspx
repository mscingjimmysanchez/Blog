<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True" CodeBehind="EditUser.aspx.cs" Inherits="EditUser" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <h2>Edit
    </h2>
    <div class="form-horizontal">
        <h4>User</h4>
        <hr />
        <div class="form-group">
            <label class="col-md-2 for="Name">Name</label>
            <div class="col-md-10">
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvName" runat="server" ErrorMessage="* Name is required" ControlToValidate="TxtName"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Login">Login</label>
            <div class="col-md-10">
                <asp:TextBox ID="TxtLogin" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvLogin" runat="server" ErrorMessage="* Login is required" ControlToValidate="TxtLogin"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-2" for="Password">Password</label>
            <div class="col-md-10">
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="* Password is required" ControlToValidate="TxtPassword"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-0 col-md-12">
                <asp:Button ID="BtnEdit" runat="server" Text="Edit" OnClick="BtnEdit_Click" CssClass="btn btn-default"></asp:Button>
                <asp:Button ID="BtnClean" runat="server" Text="Clean" OnClick="BtnClean_Click" CssClass="btn btn-default" CausesValidation="False" />
            </div>
        </div>
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
    <div>
        <a href="UserIndex.aspx">Back to List</a>
    </div>
</asp:Content>
