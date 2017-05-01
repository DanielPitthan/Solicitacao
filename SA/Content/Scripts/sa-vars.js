
//Variáveis
var qtdestoque = 0;
var dados = new Array();  

//--------------------
//Objetos do DOM


//Avisos
var avisos = document.querySelector("#avisos");
var modalTitulo = document.querySelector(".modal-title");
var modalTexto = document.querySelector(".modal-body");


//Form

var numtpr = document.querySelector("#numtpr");
var prd = document.querySelector("#produto");
var qtd = document.querySelector("#quantidade");
var obs = document.querySelector("#observacao");
var tipoReq = document.querySelector("#tprequisicao");
var dep     = document.querySelector("#departamento");
var cc = document.querySelector("#centrocusto");
var listaProduto = document.querySelector("#lstproduto");


//Botões
var btAdiciona = document.querySelector("#btincluir");

//Tables 

var tabela = document.querySelector("#tbselecionado");

//------------------------------

//Mais Variáveis
var prdDesc = prd.value.substring(15, prd.value.length);