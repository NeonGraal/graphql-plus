namespace GqlPlus.Verifier.Ast;

public record struct AstKeyValue<T>(FieldKeyAst Key, T Value)
  where T : AstValue<T>;
