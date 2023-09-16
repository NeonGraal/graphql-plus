/** @type LanguageFn */
export default function (hljs) {
  return {
    name: "Parser Expression Grammar",
    contains: [
      // Specific
      {
        begin: /=/,
        end: /$/,
        contains: [
          {
            className: "tag",
            begin: /[()?*+|]/,
          },
          {
            className: "symbol",
            begin : /\w+/,
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
