<%@ Page Language="cs" AutoEventWireup="True" MasterPageFile="~/Main.Master"
    CodeBehind="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <div>
        <div class="row">
            <div class="col-md-12">
                <h1>Login
                </h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label class="col-md-2 for="Login">Login</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TxtLogin" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvLogin" runat="server" ErrorMessage="* Login is required." ControlToValidate="TxtLogin" CssClass="field-validation-valid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Password">Password</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="* Password is required." ControlToValidate="TxtPassword" CssClass="field-validation-valid"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-0 col-md-12">
                        <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" CssClass="btn btn-default"></asp:Button>
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
        </div>
    </div>
</asp:Content>
