import { useState, useEffect } from "react";
import ListarTarefas from "./components/ListarTarefas";
import RegistrarTarefas from "./components/RegistrarTarefas";
import "./App.css";

function App() {
  const [tarefas, setTarefas] = useState([]);
  const [carregando, setCarregando] = useState(true);

  const API_URL = "https://localhost:7283/api/ToDoList";

  // Função para buscar dados (GET)
  const buscarDados = () => {
    fetch(API_URL)
      .then((res) => res.json())
      .then((dados) => {
        setTarefas(dados.toDoList || []);
        setCarregando(false);
      })
      .catch(() => setCarregando(false));
  };

  useEffect(() => {
    buscarDados();
  }, []);

  // Função que o filho vai chamar após o POST
  const adicionarNaLista = (novaTarefa) => {
    setTarefas((listaAntiga) => [...listaAntiga, novaTarefa]);
  };

  return (
    /* Mudamos a div principal para ser o "cenário" da mesa */
    <div className="cenario-mesa">
      {/* Este container é a área "focada" onde o caderno está */}
      <div className="area-caderno-container">
        {/* Esta é a div MÁGICA: o papel com linhas CSS */}
        <div className="papel-com-linhas">
          <RegistrarTarefas aoAdicionar={adicionarNaLista} />
          {/* Passamos os dados para o filho que lista */}
          <ListarTarefas tarefas={tarefas} carregando={carregando} />
        </div>
      </div>

      {/* Se quiser o formulário fora do caderno, coloque ele aqui em baixo ou em outro lugar */}
      {/* <RegistrarTarefas aoAdicionar={adicionarNaLista} /> */}
    </div>
  );
}

export default App;
