function solve(input) {
    let n = Number(input.shift());

    let guildMembers = {};

    for (let i = 0; i < n; i++) {
        let [memberName, role, skillsInfo] = input.shift().split(' ');

        let skills = skillsInfo.split(',');

        guildMembers[memberName] = {
            role: role,
            skills: skills
        };
    }

    while (input[0] !== 'End') {
        let tokens = input.shift().split(' / ');

        let command = tokens[0];
        let memberName = tokens[1];

        if (command === 'Perform') {
            let role = tokens[2];
            let skill = tokens[3];

            if (guildMembers[memberName].role === role && guildMembers[memberName].skills.includes(skill)) {
                console.log(`${memberName} has successfully performed the skill: ${skill}!`);
            } else {
                console.log(`${memberName} cannot perform the skill: ${skill}.`);
            }
        } else if (command === 'Reassign') {
            let newRole = tokens[2];

            guildMembers[memberName].role = newRole;

            console.log(`${memberName} has been reassigned to: ${newRole}`);
        } else if (command === 'Learn Skill') {
            let newSkill = tokens[2];

            if (guildMembers[memberName].skills.includes(newSkill)) {
                console.log(`${memberName} already knows the skill: ${newSkill}.`);
            } else {
                guildMembers[memberName].skills.push(newSkill);

                console.log(`${memberName} has learned a new skill: ${newSkill}.`);
            }
        }
    }

    for (let name in guildMembers) {
        let sortedSkills = guildMembers[name].skills.sort((a, b) => a.localeCompare(b));

        console.log(`Guild Member: ${name}, Role: ${guildMembers[name].role}, Skills: ${sortedSkills.join(', ')}`);
    }
}

solve(
    [
        "3",
        "Arthur warrior swordsmanship,shield",
        "Merlin mage fireball,teleport",
        "Gwen healer healing,alchemy",
        "Perform / Arthur / warrior / swordsmanship",
        "Perform / Merlin / warrior / fireball",
        "Learn Skill / Gwen / purification",
        "Perform / Gwen / healer / purification",
        "Reassign / Merlin / healer",
        "Perform / Merlin / healer / teleport",
        "End"
    ]
)