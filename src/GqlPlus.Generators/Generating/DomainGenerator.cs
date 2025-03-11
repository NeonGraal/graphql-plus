namespace GqlPlus.Generating;

internal sealed class DomainGenerator(
  IEnumerable<IDomainGenerator> generators
) : GenerateForType<IGqlpDomain>
{
  private static readonly IDomainGenerator s_default = new GenerateDefaultDomain();

  protected override void Generate(IGqlpDomain ast, GeneratorContext context)
  {
    IDomainGenerator generator = generators.Where(g => g.ForDomain(ast)).FirstOrDefault() ?? s_default;
    generator.GenerateDomain(ast, context);
  }
}
