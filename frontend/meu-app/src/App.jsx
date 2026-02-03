import { useState, useEffect } from "react";
import ListarTarefas from "./components/ListarTarefas";
import RegistrarTarefas from "./components/RegistrarTarefas";
import TarefaCompleta from "./components/TarefaCompleta";
import "./App.css";

function App() {
  const [tarefas, setTarefas] = useState([]);
  const [tarefaSelecionada, setTarefaSelecionada] = useState(null);
  const [carregandoDetalhes, setCarregandoDetalhes] = useState(false);

  const API_URL = "https://localhost:7283/api/ToDoList";

  const buscarLista = () => {
    fetch(API_URL)
      .then((res) => res.json())
      .then((dados) => setTarefas(dados.toDoList || []));
  };

  useEffect(() => {
    buscarLista();
  }, []);

  const adicionarNaLista = (novaTarefa) => {
    setTarefas((prev) => [...prev, novaTarefa]);
  };

  const abrirDetalhes = async (id) => {
    setCarregandoDetalhes(true);
    try {
      const resposta = await fetch(`${API_URL}/${id}`);
      if (resposta.ok) {
        const dados = await resposta.json();
        setTarefaSelecionada(dados);
      }
    } catch (error) {
      console.error("Erro", error);
    } finally {
      setCarregandoDetalhes(false);
    }
  };

  const voltarParaLista = () => {
    setTarefaSelecionada(null);
  };

  const excluirTarefa = async (id) => {
    const confirmacao = window.confirm(
      "Tem certeza que quer rasgar essa folha? (Excluir tarefa)",
    );
    if (!confirmacao) return;

    try {
      const resposta = await fetch(`${API_URL}/${id}`, {
        method: "DELETE",
      });

      if (resposta.ok) {
        setTarefas((listaAtual) => listaAtual.filter((t) => t.id !== id));

        setTarefaSelecionada(null);
      } else {
        alert("Não foi possível excluir a tarefa.");
      }
    } catch (error) {
      console.error("Erro ao excluir:", error);
    }
  };

  return (
    <div className="cenario-mesa">
      <div className="area-caderno-container">
        <div className="papel-com-linhas">
          {!tarefaSelecionada ? (
            <>
              <RegistrarTarefas aoAdicionar={adicionarNaLista} />

              <ListarTarefas tarefas={tarefas} aoClicar={abrirDetalhes} />
            </>
          ) : (
            <TarefaCompleta
              tarefa={tarefaSelecionada}
              carregando={carregandoDetalhes}
              aoVoltar={voltarParaLista}
              aoExcluir={excluirTarefa}
            />
          )}
        </div>
      </div>
    </div>
  );
}

export default App;
