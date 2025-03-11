﻿namespace GqlPlus.Generating;

internal sealed class GenerateDefaultType
  : ITypeGenerator
{
  public bool ForType(IGqlpType ast) => throw new NotImplementedException();

  public void GenerateType(IGqlpType ast, GeneratorContext context)
  {
    context.AppendLine("");

    if (ast is IGqlpType<string> simpleParent && !string.IsNullOrWhiteSpace(simpleParent.Parent)) {
      context.AppendLine($"// Parent {simpleParent.Parent}");
    }

    context.AppendLine($"public interface I{ast.Label}{ast.Name} {{}}");
  }
}
