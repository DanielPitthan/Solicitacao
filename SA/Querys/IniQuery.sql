INSERT INTO Departamento (Departamentos,CentroCusto)
SELECT distinct Z13_DESCDP,Z13_CC FROM Z13010
WHERE Z13_DESCDP<>''

select * from Departamento


INSERT INTO Funcao (Funcoes)
SELECT distinct Z13_FUNCAO FROM Z13010
WHERE Z13_DESCDP<>''

SELECT * FROM Funcao