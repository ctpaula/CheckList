Para executar a aplicação .NET:

1) Abrir a solução CheckList.sln.
2) Abrir o Arquivo "appsettings.json" no projeto "CheckList.Api" e configurar uma conexão com SQL Server na "CheckListSqlConnectionString"
3) Entrar em Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes
4) Entrar com o Comando "Update-Database" no console aberto para criar o banco de dados.
5) Acessar o SQL Management Studio e incluir pelo menos 1 pergunta e 2 usuários, sendo um supervisor e o outro não.
 Comandos de exemplo:
	INSERT INTO Pergunta (Questao, Parametro) VALUES ('Inspeção de calibragem dos pneus', '32psi')

	INSERT INTO Usuario (Matricula, Nome, Email, SupervisorCheckList) VALUES 
		(123, 'Cristopher', 'ctpaula1@gmail.com', 0), 
		(124, 'Supervisor', 'supervisor@empresa.com', 1)
6) 
