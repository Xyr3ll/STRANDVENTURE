using System;
using System.Collections.Generic;

public static class StrandResultDescriptions
{
    private static readonly Dictionary<string, List<string>> _descriptions = new()
    {
        ["STEM–Med"] = new List<string>
        {
            "You got STEM–Med because you’re curious about how the human body works and enjoy learning about science, medicine, and health. You like exploring biology, chemistry, and research activities.",
            "You got STEM–Med because you’re analytical and observant. You enjoy experiments, understanding diseases, and discovering ways to improve people’s well-being.",
            "You got STEM–Med because you have the patience and dedication to study complex topics in health and science. You’re the type who finds purpose in helping others through knowledge and care."
        },
        ["STEM–Eng"] = new List<string>
        {
            "You got STEM–Eng because you enjoy solving technical and mathematical problems. You love designing, building, or experimenting with machines, systems, or models.",
            "You got STEM–Eng because you think logically and work well with structured challenges. You’re interested in how things function and how to improve them through innovation.",
            "You got STEM–Eng because you have a creative yet practical mind. You like working on experiments, robotics, and projects that turn ideas into working results."
        },
        ["Software Dev"] = new List<string>
        {
            "You got Software Dev because you love technology and solving problems through programming, apps, or websites. You’re naturally curious about how systems work.",
            "You got Software Dev because you enjoy debugging, organizing logic, and finding efficient solutions. You’re the type who’s patient and persistent when solving tech issues.",
            "You got Software Dev because you like creating digital tools that make life easier. You’re innovative, tech-savvy, and enjoy building things from scratch."
        },
        ["ABM"] = new List<string>
        {
            "You got ABM because you’re good at managing tasks, organizing people, and planning projects with clear goals. You think like a leader and act like a decision-maker.",
            "You got ABM because you’re business-minded and love working with numbers, finances, and strategies. You enjoy finding smart ways to grow ideas and make them succeed.",
            "You got ABM because you’re confident, persuasive, and driven. You enjoy marketing, entrepreneurship, and turning challenges into opportunities."
        },
        ["Tourism"] = new List<string>
        {
            "You got Tourism because you’re friendly, outgoing, and love interacting with people. You enjoy guiding, hosting, and creating memorable experiences for others.",
            "You got Tourism because you’re passionate about travel and culture. You enjoy planning trips, events, and making others feel welcome and comfortable.",
            "You got Tourism because you have great communication skills and a positive attitude. You’re at your best when helping, organizing, or representing groups and communities."
        },
        ["HUMSS–VG"] = new List<string>
        {
            "You got HUMSS–VG because you’re expressive and thoughtful. You enjoy sharing stories, understanding people, and exploring culture and communication.",
            "You got HUMSS–VG because you care about people and society. You’re drawn to teamwork, leadership, and topics that involve social awareness and human behavior.",
            "You got HUMSS–VG because you like expressing yourself through writing, speaking, or creative storytelling. You have a natural talent for connecting ideas and emotions."
        },
        ["Graphics"] = new List<string>
        {
            "You got Graphics because you’re creative and artistic. You love designing, illustrating, and turning ideas into visual masterpieces.",
            "You got Graphics because you have a strong sense of style, layout, and color. You enjoy editing, branding, and digital design that communicates ideas effectively.",
            "You got Graphics because you think visually and enjoy creating things that inspire or grab attention. You have the imagination and skill for art, animation, and media design."
        },
        ["Culinary"] = new List<string>
        {
            "You got Culinary because you enjoy cooking, experimenting with recipes, and expressing creativity through food. You love seeing people enjoy what you make.",
            "You got Culinary because you’re patient, hardworking, and have great attention to detail in food preparation and presentation.",
            "You got Culinary because you’re passionate about flavors, teamwork, and hands-on activities. You enjoy turning ingredients into delicious and artistic dishes."
        }
    };

    public static string GetRandomDescription(string strandName)
    {
        if (_descriptions.TryGetValue(strandName, out var list) && list.Count > 0)
        {
            var rand = new Random();
            return list[rand.Next(list.Count)];
        }
        return "";
    }
}