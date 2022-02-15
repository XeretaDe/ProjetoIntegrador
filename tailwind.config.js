module.exports = {
    content: ["**/*.cshtml", "**/*.html, **/*.razor"],
    theme: {
        screens: {
            xm: "400px",

            sm: "640px",
            // => @media (min-width: 640px) { ... }

            md: "768px",
            // => @media (min-width: 768px) { ... }

            lg: "1024px",
            // => @media (min-width: 1024px) { ... }

            xl: "1280px",
            // => @media (min-width: 1280px) { ... }

            "2xl": "1536px",
            // => @media (min-width: 1536px) { ... }
        },
        extend: {
            dropShadow: {
                '2xlV2': '2px 3px 4px black'

            },
            fontFamily: {
                arimo: ["Arimo"],
                Bree: ["Bree+Serif"],
                inter: ["Inter"],
                Syne: ['Syne Tactile']
            },
            colors: {
                "dark-color": "#333446",
                "natural-white": "#F8F8FF",
                "twitter-color": "#1DA1F2",
                "instagram-color": "#E1306C",
                "youtube-color": "#FF0000",
            },
        },
    },
};
