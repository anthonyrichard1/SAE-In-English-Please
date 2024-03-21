package sae.android.sae_2a.game

import android.widget.GridLayout
import androidx.compose.foundation.Image
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.layout.wrapContentWidth
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.grid.GridCells
import androidx.compose.foundation.lazy.grid.GridItemSpan
import androidx.compose.foundation.lazy.grid.LazyGridScope
import androidx.compose.foundation.lazy.grid.LazyVerticalGrid
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Card
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import sae.android.sae_2a.data.Vocabulary
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.RectangleShape
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.sp
import sae.android.sae_2a.R

@Composable
fun VocabularyScreen(){
    val vocabulary = listOf(
        Vocabulary("test","Autheur", hashMapOf("Fromage" to "Cheese", "Pomme" to "Apple")),
        Vocabulary("test2","Autheur2", hashMapOf("Fromage" to "Cheese", "Pomme" to "Apple"))
    )
    DisplayLists(vocabulary)
}

@Composable
fun DisplayLists(vocabulary: List<Vocabulary>) {
    LazyVerticalGrid( columns = GridCells.Adaptive(150.dp),
        horizontalArrangement = Arrangement.spacedBy(10.dp),
        verticalArrangement = Arrangement.spacedBy(10.dp)) {
        items(vocabulary.size) { voc ->
            VocCard(vocabulary[voc])
            Spacer(modifier = Modifier.size(10.dp))
        }
    }
}


@Composable
fun VocCard(vocabulary: Vocabulary){
    Card(shape = RectangleShape,
        modifier = Modifier
            .size(150.dp, 150.dp)
            .border(2.dp, Color.DarkGray, shape = RoundedCornerShape(8.dp, 8.dp))) {
        Text(vocabulary.name,
            modifier = Modifier
                .fillMaxWidth()
                .border(2.dp, Color.DarkGray, shape = RoundedCornerShape(8.dp, 8.dp)),
            fontSize = 20.sp,
            textAlign = TextAlign.Center)
        Spacer(modifier = Modifier.fillMaxHeight(0.05f))
        Image(painter = painterResource(id = R.drawable.words),
            contentDescription = stringResource(id = R.string.voc_image_description),
            modifier = Modifier
                .weight(1f)
                .align(Alignment.CenterHorizontally)
        )
        Text( stringResource(id = R.string.created_by) + (vocabulary.aut ?: stringResource(id = R.string.unknown)),
            modifier = Modifier
                .wrapContentHeight(Alignment.Bottom)
                .align(Alignment.End)
                .padding(5.dp),
            fontSize = 12.sp)
    }
}

@Preview
@Composable
fun PreviewCard(){
    val laMap = HashMap<String, String>()
    laMap["Fromage"] = "Cheese"
    laMap["Pomme"] = "Apple"
    VocCard(Vocabulary("test","Autheur", laMap))
}