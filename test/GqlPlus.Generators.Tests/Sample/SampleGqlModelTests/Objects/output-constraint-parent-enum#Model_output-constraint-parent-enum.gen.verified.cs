//HintName: Model_output-constraint-parent-enum.gen.cs
// Generated from output-constraint-parent-enum.graphql+

/*
*/

namespace GqlTest.Model_output_constraint_parent_enum;

public interface IOutpCnstPrntEnum
{
  RefOutpCnstPrntEnum<parentOutpCnstPrntEnum> AsRefOutpCnstPrntEnum { get; }
}
public class OutputOutpCnstPrntEnum
  : IOutpCnstPrntEnum
{
  public RefOutpCnstPrntEnum<parentOutpCnstPrntEnum> AsRefOutpCnstPrntEnum { get; set; }
}

public interface IRefOutpCnstPrntEnum<Ttype>
{
  Ttype field { get; }
}
public class OutputRefOutpCnstPrntEnum<Ttype>
  : IRefOutpCnstPrntEnum<Ttype>
{
  public Ttype field { get; set; }
}

public enum EnumOutpCnstPrntEnum
{
  parentOutpCnstPrntEnum = ParentOutpCnstPrntEnum.parentOutpCnstPrntEnum,,
  outpCnstPrntEnum,
}

public enum ParentOutpCnstPrntEnum
{
  parentOutpCnstPrntEnum,
}
