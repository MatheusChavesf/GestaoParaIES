using GestaoProffff.Models;
using GestaoProffff.Repository;
using GestaoProffff.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly ICertificadoRepository _certificadoRepository;
        private readonly IMensalidadeRepository _mensalidadeRepository;
        private readonly IPresencaRepository _presencaRepository;
        private readonly ITurmaRepository _turmaRepository;


        public HomeController(ILogger<HomeController> logger, IAlunoRepository alunoRepository, IProfessorRepository professorRepository,
                                ICursoRepository cursoRepository, IDisciplinaRepository disciplinaRepository, IAvaliacaoRepository avaliacaoRepository,
                                     ICertificadoRepository certificadoRepository, IMensalidadeRepository mensalidadeRepository, IPresencaRepository presencaRepository,
                                        ITurmaRepository turmaRepository)
        {
            _logger = logger;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _cursoRepository = cursoRepository;
            _disciplinaRepository = disciplinaRepository;
            _avaliacaoRepository = avaliacaoRepository;
            _certificadoRepository = certificadoRepository;
            _mensalidadeRepository = mensalidadeRepository;
            _presencaRepository = presencaRepository;
            _turmaRepository = turmaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aluno()
        {
            var alunos = _alunoRepository.BuscarAlunos();
            return View("Aluno", alunos);
        }

        [HttpGet]
        public IActionResult AdicionarAluno()
        {
            
            Random random = new Random();
            int matriculaAleatoria = random.Next(1000, 9999);
            
            var aluno = new AlunoModel
            {
                MatriculaAluno = matriculaAleatoria,             
            };

            return View(aluno);
        }

        [HttpPost] 
        public IActionResult AdicionarAluno(AlunoModel aluno)
        {
            if (ModelState.IsValid)
            {
                _alunoRepository.AdicionarAluno(aluno);
                return RedirectToAction("Aluno");
            }
            return View(aluno);
        }

        public IActionResult Professor()
        {
            var professores = _professorRepository.BuscarProfessores();
            return View(professores);
        }


        [HttpGet]
        public IActionResult AdicionarProfessor()
        {
            
            Random random = new Random();
            int matriculaAleatoria = random.Next(1000, 9999);

            var professor = new ProfessorModel
            {
                MatriculaProfessor = matriculaAleatoria.ToString(),
                DataNascimento = DateTime.Now.AddYears(-35), 
            };

            return View(professor);
        }

        [HttpPost]
        public IActionResult AdicionarProfessor(ProfessorModel professor)
        {
            if (ModelState.IsValid)
            {
                _professorRepository.AdicionarProfessor(professor);
                return RedirectToAction("Professor");
            }
            return View(professor);
        }

        public IActionResult Curso()
        {
            var cursos = _cursoRepository.GetAllCursos();
            return View(cursos);
        }
        
        [HttpGet]
        public IActionResult CriarCurso()
        {
            Random random = new Random();
            int idCursoAleatorio = random.Next(1000, 9999);

            var curso = new CursoModel
            {
                IDCurso = idCursoAleatorio,                
                NomeCurso = string.Empty
            };

            return View(curso);
        }

        [HttpPost]
        public IActionResult CriarCurso(CursoModel curso)
        {
            if (ModelState.IsValid)
            {
                _cursoRepository.AddCurso(curso);
                return RedirectToAction("Curso");
            }
            return View(curso);
        }


        public IActionResult Disciplina()
        {
            var disciplinas = _disciplinaRepository.BuscaDisciplina();
            return View(disciplinas);
        }

        [HttpGet]
        public IActionResult CriarDisciplina()
        {
            var disciplina = new DisciplinaModel();
            disciplina.ProfessoresSelectList = new SelectList(_professorRepository.BuscarProfessores(), "IDProfessor", "NomeProfessor");

            Random random = new Random();
            disciplina.IDDisciplina = random.Next(1000, 9999);

            return View(disciplina);
        }

        [HttpPost]
        public IActionResult CriarDisciplina(DisciplinaModel disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinaRepository.AddDisciplina(disciplina);
                return RedirectToAction("Disciplina");
            }
            return View(disciplina);
        }

        [HttpGet]
        public IActionResult Avaliacao()
        {
            var avaliacoes = _avaliacaoRepository.BuscarAvaliacoesComListas();
            return View(avaliacoes);
        }

        [HttpGet]
        public IActionResult CriarAvaliacao()
        {
            var novaAvaliacao = new AvaliacaoModel();

            novaAvaliacao.IDAvaliacao = new Random().Next(1000, 9999);

            // Carrega a lista de alunos disponíveis
            novaAvaliacao.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
            
            novaAvaliacao.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();

            return View(novaAvaliacao);
        }

        [HttpPost]
        public IActionResult CriarAvaliacao(AvaliacaoModel avaliacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (avaliacao.IDAvaliacao == 0)
                    {
                        Random random = new Random();
                        avaliacao.IDAvaliacao = random.Next(1000, 9999);
                    }

                    _avaliacaoRepository.AddAvaliacao(avaliacao);
                    return RedirectToAction("Avaliacao");
                }
                avaliacao.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
                avaliacao.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();
                return View("CriarAvaliacao", avaliacao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar a avaliação no banco de dados.");
                ModelState.AddModelError(string.Empty, "Erro ao criar a avaliação.");
                avaliacao.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
                avaliacao.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();
                return View("CriarAvaliacao", avaliacao);
            }
            finally
            {
                _logger.LogInformation("Método CriarAvaliacao concluído.");
            }
        }

        public IActionResult Certificado()
        {
            var certificados = _certificadoRepository.GetCertificados();
            return View(certificados);
        }

        [HttpGet]
        public IActionResult AdicionarCertificado()
        {
            var certificado = new CertificadoModel();
            // Se necessário, você pode carregar informações adicionais para preencher o modelo.
            return View(certificado);
        }

        [HttpPost]
        public IActionResult AdicionarCertificado(CertificadoModel certificado)
        {
            if (ModelState.IsValid)
            {
                _certificadoRepository.AdicionarCertificado(certificado);
                return RedirectToAction("Certificado");
            }
            return View(certificado);
        }

        [HttpGet]
        public IActionResult EditarCertificado(int id)
        {
            var certificado = _certificadoRepository.GetCertificadoById(id);
            if (certificado == null)
            {
                return NotFound();
            }
            return View(certificado);
        }

        [HttpPost]
        public IActionResult EditarCertificado(CertificadoModel certificado)
        {
            if (ModelState.IsValid)
            {
                _certificadoRepository.AtualizarCertificado(certificado);
                return RedirectToAction("Certificado");
            }
            return View(certificado);
        }

        [HttpPost]
        public IActionResult ExcluirCertificado(int id)
        {
            _certificadoRepository.ExcluirCertificado(id);
            return RedirectToAction("Certificado");
        }

        public IActionResult Mensalidade()
        {
            var mensalidades = _mensalidadeRepository.GetMensalidades();
            return View(mensalidades);
        }

        [HttpGet]
        public IActionResult AdicionarMensalidade()
        {
            var mensalidade = new MensalidadeModel();
            
            return View(mensalidade);
        }

        [HttpPost]
        public IActionResult AdicionarMensalidade(MensalidadeModel mensalidade)
        {
            if (ModelState.IsValid)
            {
                _mensalidadeRepository.AdicionarMensalidade(mensalidade);
                return RedirectToAction("Mensalidade");
            }
            return View(mensalidade);
        }

        [HttpGet]
        public IActionResult EditarMensalidade(int id)
        {
            var mensalidade = _mensalidadeRepository.GetMensalidadeById(id);
            if (mensalidade == null)
            {
                return NotFound();
            }
            return View(mensalidade);
        }

        [HttpPost]
        public IActionResult EditarMensalidade(MensalidadeModel mensalidade)
        {
            if (ModelState.IsValid)
            {
                _mensalidadeRepository.AtualizarMensalidade(mensalidade);
                return RedirectToAction("Mensalidade");
            }
            return View(mensalidade);
        }

        [HttpPost]
        public IActionResult ExcluirMensalidade(int id)
        {
            _mensalidadeRepository.ExcluirMensalidade(id);
            return RedirectToAction("Mensalidade");
        }

        [HttpGet]
        public IActionResult AdicionarPresenca()
        {
            var novaPresenca = new PresencaModel();

            // Carrega a lista de alunos disponíveis
            novaPresenca.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();

            // Carrega a lista de disciplinas disponíveis
            novaPresenca.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();

            return View(novaPresenca);
        }

        [HttpPost]
        public IActionResult AdicionarPresenca(PresencaModel presenca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (presenca.IDPresenca == 0)
                    {
                        Random random = new Random();
                        presenca.IDPresenca = random.Next(1000, 9999);
                    }

                    _presencaRepository.AdicionarPresenca(presenca);
                    return RedirectToAction("Presenca");
                }

                // Carrega a lista de alunos disponíveis novamente em caso de erro
                presenca.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
                presenca.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();
                return View("AdicionarPresenca", presenca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar a presença no banco de dados.");
                ModelState.AddModelError(string.Empty, "Erro ao criar a presença.");

                // Carrega a lista de alunos disponíveis novamente em caso de erro
                presenca.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
                presenca.DisciplinasDisponiveis = _disciplinaRepository.BuscaDisciplina()?.ToList() ?? new List<DisciplinaModel>();
                return View("AdicionarPresenca", presenca);
            }
            finally
            {
                _logger.LogInformation("Método AdicionarPresenca concluído.");
            }
        }

        public IActionResult Turma()
        {
            var turmas = _turmaRepository.GetAllTurmas();
            return View(turmas);
        }

        [HttpGet]
        public IActionResult AdicionarTurma()
        {
            var turma = new TurmaModel
            {
                // Inicialize as propriedades necessárias da turma, se houver
            };

            // Carregue os cursos disponíveis para associar à turma
            turma.CursosDisponiveis = new SelectList(_cursoRepository.GetAllCursos(), "IDCurso", "NomeCurso");

            // Carregue os alunos disponíveis para matricular na turma
            turma.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();

            return View(turma);
        }

        [HttpPost]
        public IActionResult AdicionarTurma(TurmaModel turma)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    _turmaRepository.AddTurma(turma);
                    return RedirectToAction("Turma");
                }

                
                turma.CursosDisponiveis = new SelectList(_cursoRepository.GetAllCursos(), "IDCurso", "NomeCurso");
                turma.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();

                return View("AdicionarTurma", turma);
            }
            catch (Exception ex)
            {                
                _logger.LogError(ex, "Erro ao adicionar turma no banco de dados.");
                ModelState.AddModelError(string.Empty, "Erro ao adicionar turma.");
                turma.CursosDisponiveis = new SelectList(_cursoRepository.GetAllCursos(), "IDCurso", "NomeCurso");
                turma.AlunosDisponiveis = _alunoRepository.BuscarAlunos()?.ToList() ?? new List<AlunoModel>();
                return View("AdicionarTurma", turma);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
}
