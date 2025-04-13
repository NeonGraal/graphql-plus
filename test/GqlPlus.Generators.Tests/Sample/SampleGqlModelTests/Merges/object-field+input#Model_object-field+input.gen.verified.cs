//HintName: Model_object-field+input.gen.cs
// Generated from object-field+input.graphql+

/*
*/

namespace GqlTest.Model_object_field_input;

public interface IInpObjField
{
  FldInpObjField field { get; }
}
public class InputInpObjField
  : IInpObjField
{
  public FldInpObjField field { get; set; }
}

public interface IFldInpObjField
{
}
public class InputFldInpObjField
  : IFldInpObjField
{
}
