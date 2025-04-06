namespace GqlPlus.Generating.Simple;

internal abstract class GenerateBaseDomain<TItem>
  : IDomainGenerator
  where TItem : IGqlpDomainItem
{
  public bool ForDomain(IGqlpDomain ast)
    => ast is IGqlpDomain<TItem>;

  internal virtual void GenerateInterface(IGqlpDomain<TItem> ast, GeneratorContext context)
  { }

  internal virtual void GenerateClass(IGqlpDomain<TItem> domain, GeneratorContext context)
  { }

  public void GenerateDomain(IGqlpDomain ast, GeneratorContext context)
  {
    context.AppendLine("");

    IGqlpDomain<TItem> domain = (IGqlpDomain<TItem>)ast;

    string parent = "";
    if (!string.IsNullOrWhiteSpace(domain.Parent)) {
      parent = " : IDomain" + domain.Parent;
    }

    context.AppendLine($"public interface IDomain{domain.Name}{parent} {{");
    GenerateInterface(domain, context);
    context.AppendLine("}");


    context.AppendLine($"public class Domain{domain.Name}");
    if (!string.IsNullOrWhiteSpace(domain.Parent)) {
      context.AppendLine("  : Domain" + domain.Parent);
      context.AppendLine("  , IDomain" + domain.Name);
    } else {
      context.AppendLine("  : IDomain" + domain.Name);
    }

    context.AppendLine("{");
    GenerateClass(domain, context);
    context.AppendLine("}");
  }
}
