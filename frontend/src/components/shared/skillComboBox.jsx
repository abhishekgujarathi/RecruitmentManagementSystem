import { useState, useEffect } from "react";
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from "@/components/ui/popover";
import {
  Command,
  CommandInput,
  CommandList,
  CommandEmpty,
  CommandGroup,
  CommandItem,
} from "@/components/ui/command";
import { Button } from "@/components/ui/button";
import { ChevronsUpDown, Check } from "lucide-react";
import { cn } from "@/lib/utils";
import api from "../../services/api";

export default function SkillComboBox({ value, intialLabel, onChange }) {
  const [open, setOpen] = useState(false);
  const [skills, setSkills] = useState([]);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(false);

  // Debounce search input
  useEffect(() => {
    const timer = setTimeout(() => {
      if (open) fetchSkills(search);
    }, 300);
    return () => clearTimeout(timer);
  }, [search, open]);

  const fetchSkills = async (query) => {
    setLoading(true);

    try {
      const res = await api.get("/Skills");
      console.log("res", res);

      //   const data = await res.json();
      setSkills(res.data);
    } catch (err) {
      console.error("Skill fetch error:", err);
    } finally {
      setLoading(false);
    }
  };

  const selectedLabel =
    intialLabel ||
    skills.find((skill) => skill.skillId === value)?.name ||
    "Select skill";

  return (
    <Popover open={open} onOpenChange={setOpen}>
      <PopoverTrigger asChild>
        <Button
          variant="outline"
          role="combobox"
          className="w-full justify-between"
        >
          {selectedLabel}
          <ChevronsUpDown className="h-4 w-4 opacity-50" />
        </Button>
      </PopoverTrigger>

      <PopoverContent className="w-full p-0">
        <Command>
          <CommandInput
            placeholder="Search skills..."
            onValueChange={(val) => setSearch(val)}
          />

          <CommandList>
            {loading && (
              <div className="p-3 text-sm text-muted-foreground">Loading…</div>
            )}

            {!loading && skills.length === 0 && (
              <CommandEmpty>No skills found.</CommandEmpty>
            )}

            <CommandGroup>
              {skills.map((skill) => (
                <CommandItem
                  key={skill.skillId}
                  value={skill.skillName}
                  onSelect={() => {
                    onChange(skill.skillId, skill.name); // pass both
                    setOpen(false);
                  }}
                >
                  <Check
                    className={cn(
                      "mr-2 h-4 w-4",
                      value === skill.skillId ? "opacity-100" : "opacity-0"
                    )}
                  />
                  {skill.name}
                </CommandItem>
              ))}
            </CommandGroup>
          </CommandList>
        </Command>
      </PopoverContent>
    </Popover>
  );
}
