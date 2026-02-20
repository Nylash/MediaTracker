import { useState } from "react";
import { createMedia } from "../api";
import { useNavigate } from "react-router-dom";
import Button from "../components/ui/Button";
import Input from "../components/ui/Input";
import Select from "../components/ui/Select";

export default function AddMediaPage() {
  const [title, setTitle] = useState("");
  const [category, setCategory] = useState("Game");
  const navigate = useNavigate();

  const handleSubmit = async () => {
    await createMedia(title, category);
    navigate("/");
  };

  return (
    <div>
      <h1>Ajouter un média</h1>

      <Input
        placeholder="Titre"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />

      <Select
        value={category}
        onChange={(e) => setCategory(e.target.value)}
      >
        <option value="Game">Game</option>
        <option value="Movie">Movie</option>
        <option value="Series">Series</option>
        <option value="Book">Book</option>
      </Select>

      <Button onClick={handleSubmit}>Ajouter</Button>
    </div>
  );
}