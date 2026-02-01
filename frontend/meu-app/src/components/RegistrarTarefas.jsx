import { useState } from "react";

export default function RegistrarTarefas({ aoAdicionar }) {
  // Recebe a prop aqui
  const [nome, setNome] = useState("");
  const [description, setDescription] = useState("");

  const adicionarTarefa = async (e) => {
    e.preventDefault();
    const novaTarefaObj = {
      name: nome,
      description: description,
      priority: "Normal",
      dueDate: new Date().toISOString(),
      status: "2",
    };

    try {
      const resposta = await fetch("https://localhost:7283/api/ToDoList", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(novaTarefaObj),
      });

      if (resposta.ok) {
        const tarefaCriada = await resposta.json();
        aoAdicionar(tarefaCriada); // <--- AQUI: Avisa o Pai para atualizar a lista!
        setNome("");
        setDescription("");
      }
    } catch (erro) {
      console.error("Erro ao adicionar", erro);
    }
  };

  return (
    <form onSubmit={adicionarTarefa}>
      <h2>Registrar Nova tarefa</h2>
      <input
        value={nome}
        onChange={(e) => setNome(e.target.value)}
        required
        placeholder="Nome"
      />
      <input
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        required
        placeholder="Descrição"
      />
      <button type="submit">Adicionar</button>
    </form>
  );
}
