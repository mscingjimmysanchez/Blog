﻿<%@ Page Language="cs" MasterPageFile="~/Main.Master" AutoEventWireup="True" CodeBehind="DeleteCategory.aspx.cs" Inherits="DeleteCategory" %>

<asp:Content ID="CntContent" runat="server" ContentPlaceHolderID="CphHome">
    <h2>Delete
    </h2>
    <div class="form-horizontal">
        <h4>Category</h4>
        <hr />
        <div class="form-group">
            <label class="col-md-2" for="Category">Category</label>
            <div class="col-md-12">
                <asp:Label ID="LblCategory" runat="server"></asp:Label>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-0 col-md-12">
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click" CssClass="btn btn-default"></asp:Button>
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
        <a href="CategoryIndex.aspx">Back to List</a>
    </div>
</asp:Content>
