import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";

function RoundFeedBackSection({ round, onRoundChange, onSubmit }) {
  // update a skill rating
  const updateSkillRating = (skillIndex, rating) => {
    const newSkills = [...round.feedbacks[0].skillRatings];
    newSkills[skillIndex].rating = rating;
    onRoundChange({ ...round, skillRatings: newSkills });
  };

  // update round comment
  const updateComment = (comment) => {
    if (!round.feedbacks || round.feedbacks.length === 0) return;

    onRoundChange({
      ...round,
      feedbacks: round.feedbacks.map((f, index) =>
        index === 0 ? { ...f, comments: comment } : f
      ),
    });
  };

  return (
    <Card>
      {console.log(round.feedbacks[0].skillRatings)}
      <CardHeader>
        <CardTitle className="text-sm">{round.roundType}</CardTitle>
        <span className="text-xs text-muted-foreground">{round.status}</span>
      </CardHeader>

      <CardContent className="space-y-3">
        {round.feedbacks[0].skillRatings?.map((skill, idx) => (
          <div key={skill.skillId} className="flex items-center gap-3">
            <span className="flex-1 text-sm">{skill.skillName}</span>

            <Select
              value={skill.rating?.toString()}
              onValueChange={(v) => updateSkillRating(idx, Number(v))}
            >
              <SelectTrigger className="w-20">
                <SelectValue placeholder="Rate" />
              </SelectTrigger>
              <SelectContent>
                {[1, 2, 3, 4, 5].map((n) => (
                  <SelectItem key={n} value={n.toString()}>
                    {n}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>
        ))}

        <Textarea
          placeholder="Interview comments"
          value={round.feedbacks[0].comments ?? ""}
          onChange={(e) => updateComment(e.target.value)}
        />

        <Button size="sm" onClick={() => onSubmit(round)}>
          Save Feedback
        </Button>
      </CardContent>
    </Card>
  );
}

export default RoundFeedBackSection;
