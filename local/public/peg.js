/** @type LanguageFn */
export default function (hljs) {
  return {
    name: "Parser Expression Grammar",
    disableAutodetect: false,
    contains: [
      // Specific
      {
        begin: /=/,
        end: /$/,
        contains: [
          {
            className: "symbol",
            begin: /[()?*+|]/,
          },
          {
            className: "variable",
            begin: /[a-z]\w+/,
          },
          {
            className: "keyword",
            begin: /[A-Z]\w+/,
          },
          // Common
          hljs.HASH_COMMENT_MODE,
          hljs.APOS_STRING_MODE,
          hljs.QUOTE_STRING_MODE,
        ],
      },
    ],
  };
}
