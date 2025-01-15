using  static System.Console;
using Model;
using Model.Repository;
using System.Collections.Generic;
using System;

IRepository<Aluno> alunoRepo = null;
IRepository<Professor> professorRepo = null; 
IRepository<Turma> turmaRepo = null; 
IRepository<Disciplina> disciplinaRepo = null; 

alunoRepo = new AlunoFakeRepository();
professorRepo = new ProfessorFakeRepository();
turmaRepo = new TurmaFakeRepository();
disciplinaRepo = new DisciplinaFakeRepository();

while(true) {
    try
    {
        Clear();
        WriteLine("""
            1 - Cadastrar Professor
            2 - Cadastrar Aluno
            3 - Cadastrar Turma
            4 - Cadastrar Disciplina
            5 - Ver professores
            6 - Ver alunos
            7 - Ver turma
            8 - Ver disciplina
            9- Sair
        """);

        int option = int.Parse(ReadLine());

        switch (option)
        {
            case 1:
                Clear();
                Professor professor = new();
                WriteLine("Insira o id do professor: ");
                professor.Id = int.Parse(ReadLine());
                WriteLine("Insira o nome do professor: ");
                professor.Nome = ReadLine();
                WriteLine("Insira a formação: ");
                professor.Formacao = ReadLine();
                professorRepo.Add(professor);
                break;

            case 2:
                Clear();
                Aluno aluno = new();
                WriteLine("Insira o id do aluno: ");
                aluno.Id = int.Parse(ReadLine());
                WriteLine("Insira o nome do aluno: ");
                aluno.Nome = ReadLine();
                WriteLine("Insira a idade do aluno: ");
                aluno.Idade = int.Parse(ReadLine());
                alunoRepo.Add(aluno);
                break;

            case 3:
                Clear();

                Turma turma = new();
                WriteLine("Insira o codigo da turma: ");
                turma.Id = int.Parse(ReadLine());
                WriteLine("Insira o periodo: ");
                turma.Periodo = ReadLine();
                
                WriteLine("\nLista de professores cadastrados: ");
                foreach (var prof in professorRepo.All)
                {
                    WriteLine($"{prof.Id} - {prof.Nome} - {prof.Formacao}");
                };
                WriteLine("\nInsira o id do professor: ");
                turma.Professor = int.Parse(ReadLine());

                WriteLine("\nLista de alunos cadastrados: ");
                foreach (var alun in alunoRepo.All)
                {
                    WriteLine($"{alun.Id} - {alun.Nome} - {alun.Idade}");
                };

                WriteLine("\n");
                
                List<int> alunosTurma = [];
                while(true) {

                    WriteLine($"Digite o ID do aluno para adicionar ou -1 para prosseguir: ");
                    int id = int.Parse(ReadLine());

                    if(id == -1) {
                        break;
                    } else {
                        alunosTurma.Add(id);
                    }
                }

                turma.Alunos = alunosTurma;
                turmaRepo.Add(turma);
                break;

            case 4:
                Clear();
                Disciplina disciplina = new();
                WriteLine("Insira o codigo da disciplina: ");
                disciplina.Id = int.Parse(ReadLine());
                WriteLine("Insira o nome do disciplina: ");
                disciplina.Nome = ReadLine();

                WriteLine("\nLista de professores cadastrados: ");
                foreach (var prof in professorRepo.All)
                {
                    WriteLine($"{prof.Id} - {prof.Nome} - {prof.Formacao}");
                };

                List<int> profsDisciplina = [];
                while(true) {

                    WriteLine($"Digite o ID do professor para adicionar ou 0 para prosseguir: ");
                    int id = int.Parse(ReadLine());

                    if(id == 0) {
                        break;
                    } else {
                        profsDisciplina.Add(id);
                    }
                }

                disciplinaRepo.Add(disciplina);
                break;

            case 5:
                var profs = professorRepo.All;
                foreach (var prof in profs)
                {
                    WriteLine($"""
                        {prof.Id} - {prof.Formacao} - {prof.Nome}
                    ---------------------------------
                    """);
                };
                break;

            case 6:
                var alunos = alunoRepo.All;
                foreach (var alun in alunos)
                {
                    WriteLine($"""
                        {alun.Id} - {alun.Nome} - {alun.Idade}
                    ---------------------------------
                    """);
                };
                break;

            case 7:
                var turmas = turmaRepo.All;
                WriteLine("""
                ---------------------------------
                """);

                foreach (var turm in turmas)
                {
                    WriteLine($"""
                        Turma: {turm.Id} - Período: {turm.Periodo}
                        Professor responsável: {turm.Professor}
                        Alunos matriculados:
                    """);

                    foreach (var id in turm.Alunos)
                    {
                        var alun = alunoRepo.findById(id);
                        WriteLine($"""
                            {alun.Id} - {alun.Nome}
                        """);
                    };

                    WriteLine("""
                    ---------------------------------
                    """);
                };
                break;

            case 8:
                var disciplinas = disciplinaRepo.All;

                WriteLine("""
                ---------------------------------
                """);

                foreach (var disc in disciplinas)
                {
                    WriteLine($"""
                        Disciplina: {disc.Id} - {disc.Nome}
                        Professores:
                    """);

                    foreach (var id in disc.Professores)
                    {
                        var prof = professorRepo.findById(id);
                        WriteLine($"""
                            {prof.Id} - {prof.Nome}
                        """);
                    };

                    WriteLine("""
                    ---------------------------------
                    """);
                };
                break;

            case 9:
                return;
            
            default:
                break;
        }
    }
    catch (Exception e )
    {   
        // WriteLine(e);
        WriteLine("Erro na aplicação, por favor consulte a TI");
    }

    WriteLine("Pressione qualquer tecla para continuar...");
    ReadKey(true);
}