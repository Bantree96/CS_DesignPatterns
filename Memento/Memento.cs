using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    // 메멘토 클래스 (파일로 직렬화 하기 위한 어트리뷰트 설정)
    [Serializable]
    internal class Memento
    {
        private int data;
        private int state;
    }
}
