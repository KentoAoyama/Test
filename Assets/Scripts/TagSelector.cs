using UnityEngine;
using UnityEditor;

/// <summary>
/// �^�O�̑I�����s����悤�ɂ���A�g���r���[�g
/// </summary>
public class TagSelectorAttribute : PropertyAttribute�@//�J�X�^���v���p�e�B�[������h��������x�[�X�N���X
{                                                      //���̑���������X�N���v�g�ϐ����C���X�y�N�^�[��łǂ��\������邩���䂷��
    public TagSelectorAttribute() { }
}


//PropertyDrawer �܂��� DecoratorDrawer�N���X�ɁA����Drawer���ǂ̎��s�� Serializable�N���X�� PropertyAttribute�ł��邩��ʒm����
[CustomPropertyDrawer(typeof(TagSelectorAttribute))]
////=====PropertyDrawer�Ƃ�=====
//CustomPropertyDrawer�̊��N���X�B�쐬���� Serializable�N���X �� PropertyAttribute�ϐ���
//CustomDrawer���쐬���Ďg�p���邱�Ƃ��ł���B
public class TagSelectorDrawer : PropertyDrawer
{
    /// <summary>
    ///���̃��\�b�h���I�[�o�[���C�h���邱�ƂŁA�v���p�e�B�p�̓Ǝ��ɐ��䂳��� GUI(IMGUI)�@���쐬�ł���B
    /// </summary>
    /// <param name="position">�v���p�e�B GUI �Ɏg�p����`�̎w��</param>
    /// <param name="property">�C���X�y�N�^�[�ɕ\�����邽�߂̏��</param>
    /// <param name="label">�C���X�y�N�^�[�ɂǂ̂悤�ɕ\�����邩��߂�N���X</param>
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //=====PropertyWrapper�Ƃ�=====
        //�u�v���p�e�B�̐U�镑����ύX�E�ǉ����A�ȒP�ɍė��p�v���邽�߂̎d�g��

        //=====BeginProperty�Ƃ�=====
        //SerializedProperty�� GUI �ŊǗ����₷������悤�ɂ��邽�߂� PropertyWrapper �ł��� GUI�O���[�v ���쐬����
        EditorGUI.BeginProperty(position, label, property);

        //=====attribute�Ƃ�=====
        //PropertyAttribute��\���v���p�e�B�@->�@public PropertyAttribute attribute { get; }
        var attrib = this.attribute as TagSelectorAttribute;

        if (attrib == null)
        {
            //=====EndProperty�Ƃ�=====
            //BeginProperty �ƊJ�n���� Property Wrapper ���I�����܂��B
            EditorGUI.EndProperty();
            return;
        }

        //=====TagField�Ƃ�=====
        //position -> �\���ʒu
        //TagField -> �t�B�[���h�̃��x��
        //property -> �t�B�[���h���\������^�O

        //EditorGUI�̌����̃��t�@�����X
        //https://docs.unity3d.com/ja/2018.4/ScriptReference/EditorGUI.html
        property.stringValue = EditorGUI.TagField(position, label, property.stringValue);

        EditorGUI.EndProperty();
    }
}